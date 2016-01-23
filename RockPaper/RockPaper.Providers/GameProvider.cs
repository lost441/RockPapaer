// <copyright file="GameProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

using RockPaper.Contracts.Providers;

namespace RockPaper.Providers
{
    using AdapterImplentations;
    using Contracts;
    using Contracts.Common;
    using System;
    using System.Linq;

    /// <summary>
    /// The interface for Game Provider.
    /// </summary>
    public class GameProvider : IGameProvider
    {
        /// <summary>
        /// Finds a game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>The Game Id</returns>
        public Guid GetNextAvailableGame(Guid teamId)
        {
            var gameAdapter = new GameAdapter();
            var teamAdapter = new TeamAdapter();

            var team  = teamAdapter.GetTeamById(teamId);
            var game = gameAdapter.FindAvailableGame() ?? gameAdapter.RegisiterNewGame();

            gameAdapter.JoinExistingGame(team, game.Id);
            gameAdapter.SaveChanges();

            return game.Id;
        }
        
        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>A bool indicating if its the teams turn.</returns>
        public bool IsItMyTurn(Guid gameId, Guid teamId)
        {
            var gameAdapter = new GameAdapter();

            var game = gameAdapter.GetGameById(gameId);
            if (game.Team1.Id == teamId && game.GameState == GameState.Player1Hand)
            {
                return true;
            }

            return game.Team2.Id == teamId && game.GameState == GameState.Player2Hand;
        }

        /// <summary>
        /// Determines the winner.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        public void CompleteRound(Guid gameId)
        {
            var numberOfRounds = Properties.Settings.Default.BestOutOf;
            var roundsAdapter = new RoundAdapter();
            var gameAdapter = new GameAdapter();

            var completedRounds = roundsAdapter.GetCompletedRoundByGameId(gameId);
            if (completedRounds.Count() == numberOfRounds)
            {
                gameAdapter.UpdateGameState(GameState.Complete, gameId);
            }
            gameAdapter.SaveChanges();
        }
    }
}
