// <copyright file="GameProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.Providers
{
    using AdapterImplentations;
    using Contracts.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Providers;

    /// <summary>
    /// The interface for Game Provider.
    /// </summary>
    public class GameProvider : IGameProvider
    {
        /// <summary>
        /// Finds a game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="playAgainstSimulator">if set to <c>true</c> [play against simulator].</param>
        /// <returns>The Game Id</returns>
        public Guid GetNextAvailableGame(Guid teamId, bool playAgainstSimulator = false)
        {
            var gameAdapter = AdapterFactory.GetGameAdapter();
            var teamAdapter = AdapterFactory.GetTeamAdapter();
            var gameId = Guid.Empty;

            var team  = teamAdapter.GetTeamById(teamId);

            if (playAgainstSimulator)
            {
                gameId = GetSimulatedGame(team);

            }
            else
            {
                gameId = (gameAdapter.FindAvailableGame() ?? gameAdapter.RegisiterNewGame()).Id;
            }
            gameAdapter.SaveChanges();
            gameAdapter.JoinExistingGame(team, gameId);
            gameAdapter.SaveChanges();

            if (!playAgainstSimulator)
            {
                return gameId;
            }

            gameAdapter = AdapterFactory.GetGameAdapter();
            var game = gameAdapter.GetGameById(gameId);

            if (game.IsComplete)
            {
                return gameId;
            }

            var roundProvider = ProviderFactory.GetRoundProvider();
            roundProvider.SumbitSimulatedHand(game);
            
            return gameId;
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

            if (game.GameState == GameState.WaitingForPlayers)
            {
                return false;
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
            var roundsAdapter = AdapterFactory.GetRoundAdapter();
            var gameAdapter = AdapterFactory.GetGameAdapter();

            var completedRounds = roundsAdapter.GetCompletedRoundByGameId(gameId);
            if (completedRounds.Count() == numberOfRounds)
            {
                gameAdapter.UpdateGameState(GameState.Complete, gameId);
            }

            gameAdapter.SaveChanges();
        }

        /// <summary>
        /// Gets the game by identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        public Game GetGameById(Guid gameId)
        {
            var adapter = AdapterFactory.GetGameAdapter();
            return adapter.GetGameById(gameId);
        }

        /// <summary>
        /// Gets all games for dashboard games.
        /// </summary>
        /// <param name="numberOfGames">The number of games.</param>
        /// <returns>DashboardGames</returns>
        public IEnumerable<Game> GetAllGamesForDashboardGames(int? numberOfGames = null)
        {
            numberOfGames = numberOfGames ?? Properties.Settings.Default.DefaultMaxDashboardGames;

            var adapter = AdapterFactory.GetGameAdapter();
            return adapter.GetGamesForDashbaord(numberOfGames.Value);
        }

        /// <summary>
        /// Gets the simulated game.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns>The simulated team</returns>
        protected Guid GetSimulatedGame(Team team)
        {
            var gameAdapter = AdapterFactory.GetGameAdapter();
            var game = gameAdapter.RegisiterSimulatorGame(Properties.Settings.Default.SimulatorTeamName);

            gameAdapter.SaveChanges();

            return game.Id;
        }
    }
}
