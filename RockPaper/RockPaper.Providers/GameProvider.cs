// <copyright file="GameProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.Providers
{
    using RockPaper.AdapterImplentations;
    using RockPaper.Contracts;
    using RockPaper.Contracts.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The interface for Game Provider.
    /// </summary>
    public class GameProvider : IGameProvider
    {
        /// <summary>
        /// Finds a game.
        /// </summary>
        /// <param name="TeamId">The team identifier.</param>
        /// <returns></returns>
        public Guid FindAGame(Guid TeamId)
        {
            var gameAdapter = new GameAdapter();
            var teamAdapter = new TeamAdapter();

            var team  = teamAdapter.GetTeamById(TeamId);

            var game = gameAdapter.FindAvailableGame();

            if (game == null)
            {
                game = gameAdapter.RegisiterNewGame();
            }

            gameAdapter.JoinExistingGame(team, game.Id);
            gameAdapter.SaveChanges();

            return game.Id;
        }

        /// <summary>
        /// Gets the state of the game.
        /// </summary>
        /// <param name="GameId">The game identifier.</param>
        /// <returns></returns>
        public GameState GetGameState(Guid GameId)
        {
            var gameAdapter = new GameAdapter();
            return gameAdapter.GetGameState(GameId);
        }

        /// <summary>
        /// Determines the winner.
        /// </summary>
        /// <param name="GameId">The game identifier.</param>
        public void GameProcesssing(Guid GameId)
        {
            var numberOfRounds = Properties.Settings.Default.BestOutOf;
            var roundsAdapter = new RoundAdapter();
            var gameAdapter = new GameAdapter();

            var completedRounds = roundsAdapter.GetCompletedRoundByGameId(GameId);
            if (completedRounds.Count() == numberOfRounds)
            {
                gameAdapter.UpdateGameState(GameState.Complete, GameId);
            }
            gameAdapter.SaveChanges();
        }
    }
}
