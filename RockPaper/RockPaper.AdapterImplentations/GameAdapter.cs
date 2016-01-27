// <copyright file="GameAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.AdapterImplentations
{
    using Adapter;
    using Contracts.Common;
    using DataSource;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Instrumentation.Logging;

    /// <summary>
    /// The Game Adapter.
    /// </summary>
    public class GameAdapter : IGameAdapter
    {
        /// <summary>
        /// The logger
        /// </summary>
        private Logging logger = LogFactory.Create();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameAdapter"/> class.
        /// </summary>
        public GameAdapter()
        {
            context = new RockPapercContext();
        }

        /// <summary>
        /// The context
        /// </summary>
        private RockPapercContext context;

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
                //context.Dispose();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Gets all games.
        /// </summary>
        /// <returns>All the games</returns>
        public IEnumerable<Contracts.Providers.Game> GetAllGames()
        {
            return context.Games.Map();
        }

        /// <summary>
        /// Gets the game by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The game</returns>
        public Contracts.Providers.Game GetGameById(Guid id)
        {
            return context.Games.Single(x => x.Id == id).Map();
        }

        /// <summary>
        /// Regisiters the new game.
        /// </summary>
        /// <returns></returns>
        public Contracts.Providers.Game RegisiterNewGame()
        {
            var game = new Game
            {
                Id = Guid.NewGuid(),
                IsComplete = false,
                GameState = GameState.WaitingForPlayers.ToString(),
                CreatedDate = DateTime.Now,
                IsSimulatedGame = false
            };

            return context.Games.Add(game).Map();
        }

        /// <summary>
        /// Regsiters the new game.
        /// </summary>
        /// <param name="simulatedTeamName">Name of the simulated team.</param>
        /// <returns>The registered game</returns>
        public Contracts.Providers.Game RegisiterSimulatorGame(string simulatedTeamName)
        {
            var simulatorTeam = context.Team.FirstOrDefault(t => t.TeamName == simulatedTeamName);
            if (simulatorTeam == null)
            {
                var newTeam = new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = simulatedTeamName
                };

                simulatorTeam = context.Team.Add(newTeam);
            }

            var game = new Game
            {
                Id = Guid.NewGuid(),
                IsComplete = false,
                Team1 = simulatorTeam,
                GameState = GameState.WaitingForPlayers.ToString(),
                CreatedDate = DateTime.Now,
                IsSimulatedGame = true
            };

            return context.Games.Add(game).Map();
        }

        /// <summary>
        /// Joins the existing game.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        public Contracts.Providers.Game JoinExistingGame(Contracts.Providers.Team team, Guid gameId)
        {
            var gameToJoin = context.Games.Single(x => x.Id == gameId);
            var teamToBeJoining = context.Team.Single(x => x.Id == team.Id);

            if (gameToJoin.Team1 == null)
            {
                gameToJoin.Team1 = teamToBeJoining;
                gameToJoin.GameState = GameState.WaitingForPlayers.ToString();
                return gameToJoin.Map();
            }

            gameToJoin.Team2 = teamToBeJoining;
            gameToJoin.GameState = GameState.Player1Hand.ToString();
            return gameToJoin.Map();
        }

        /// <summary>
        /// Finds the available game.
        /// </summary>
        /// <returns></returns>
        public Contracts.Providers.Game FindAvailableGame()
        {
            var availbleGame = context.Games
                .Where(x => x.Team1 != null &&
                            x.Team2 == null)
                .OrderBy(x => x.CreatedDate);

            var game = availbleGame.FirstOrDefault();
            if (game != null)
            {
                return game.Map();
            }

            return null;
        }

        /// <summary>
        /// Gets the state of the game.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        public GameState GetGameState(Guid gameId)
        {
            var state = context.Games.Single(x => x.Id == gameId).GameState;
            return (GameState)Enum.Parse(typeof(GameState), state, true);
        }

        /// <summary>
        /// Updates the game.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Contracts.Providers.Game UpdateGame(Contracts.Providers.Game game)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the winning team.
        /// </summary>
        /// <param name="winningTeam">The winning team.</param>
        /// <param name="gameId">The game identifier.</param>
        public void UpdateWinningTeam(string winningTeam, Guid gameId)
        {
            var game = context.Games.Single(x => x.Id == gameId);
            game.WinningTeam = winningTeam;
        }

        /// <summary>
        /// Updates the state of the game.
        /// </summary>
        /// <param name="gameState">State of the game.</param>
        /// <param name="gameId">The game identifier.</param>
        public void UpdateGameState(GameState gameState, Guid gameId)
        {
            var game = context.Games.Single(x => x.Id == gameId);
            game.GameState = gameState.ToString();

            if (gameState == GameState.Complete)
            {
                game.IsComplete = true;
                DetermineWinner(gameId);
            };
        }

        /// <summary>
        /// Determines the winner.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        private void DetermineWinner(Guid gameId)
        {
            var roundAdapter = new RoundAdapter();
            var roundsForGame = roundAdapter.GetCompletedRoundByGameId(gameId);

            var team1Wins = roundsForGame.Count(x => x.Result == RoundResult.Team1Won);
            var team2Wins = roundsForGame.Count(x => x.Result == RoundResult.Team2Won);

            UpdateWinningTeam(team1Wins > team2Wins ? "Team1" : "Team2", gameId);
        }

        /// <summary>
        /// Gets the games for dashbaord.
        /// </summary>
        /// <param name="numberOfGames">The number of games.</param>
        /// <returns>Dashboard games</returns>
        public IEnumerable<Contracts.Providers.Game> GetGamesForDashbaord(int numberOfGames)
        {
            var games = context.Games
                .OrderBy(g => !g.IsComplete)
                .ThenByDescending(g => g.CreatedDate)
                .Take(numberOfGames);

            return games.Map();
        }
    }
}
