// <copyright file="GameAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.AdapterImplentations
{
    using RockPaper.Adapter;
    using RockPaper.Contracts;
    using RockPaper.Contracts.Common;
    using RockPaper.DataSource;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The Game Adapter.
    /// </summary>
    public class GameAdapter : IGameAdapter
    {
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
                context.Dispose();
            }
            catch (Exception ex)
            {
                //TODO: Add logging.
            }
        }

        /// <summary>
        /// Gets all games.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RockPaper.Contracts.Game> GetAllGames()
        {
            return context.Games.Map();
        }

        /// <summary>
        /// Gets the game by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public RockPaper.Contracts.Game GetGameById(Guid Id)
        {
            return context.Games.Single(x => x.Id == Id).Map();
        }

        /// <summary>
        /// Regisiters the new game.
        /// </summary>
        /// <returns></returns>
        public RockPaper.Contracts.Game RegisiterNewGame()
        {
            var game = new RockPaper.DataSource.Game
            {
                Id = Guid.NewGuid(),
                IsComplete = false,
                GameState = GameState.WaitingForPlayers.ToString(),
                CreatedDate = DateTime.Now
            };

            return context.Games.Add(game).Map();
        }

        /// <summary>
        /// Joins the existing game.
        /// </summary>
        /// <param name="Team">The team.</param>
        /// <param name="GameId">The game identifier.</param>
        /// <returns></returns>
        public RockPaper.Contracts.Game JoinExistingGame(RockPaper.Contracts.Team Team, Guid GameId)
        {
            var gameToJoin = context.Games.Single(x => x.Id == GameId);
            var teamToBeJoining = context.Team.Single(x => x.Id == Team.Id);

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
        public RockPaper.Contracts.Game FindAvailableGame()
        {
            var availbleGame = context.Games
                .Where(x => x.Team1 != null || 
                            x.Team2 == null)
                 .OrderBy(x => x.CreatedDate);

            return availbleGame.FirstOrDefault().Map();
        }

        /// <summary>
        /// Gets the state of the game.
        /// </summary>
        /// <param name="GameId">The game identifier.</param>
        /// <returns></returns>
        public GameState GetGameState(Guid GameId)
        {
            var state = context.Games.Single(x => x.Id == GameId).GameState;
            return (GameState)Enum.Parse(typeof(GameState), state, true);
        }


        /// <summary>
        /// Updates the game.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RockPaper.Contracts.Game UpdateGame(RockPaper.Contracts.Game game)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the winning team.
        /// </summary>
        /// <param name="winningTeam">The winning team.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public void UpdateWinningTeam(string winningTeam, Guid GameId)
        {
            var game = context.Games.Single(x => x.Id == GameId);
            game.WinningTeam = winningTeam;
        }

        /// <summary>
        /// Updates the state of the game.
        /// </summary>
        /// <param name="gameState">State of the game.</param>
        /// <param name="GameId">The game identifier.</param>
        public void UpdateGameState(GameState gameState, Guid GameId)
        {
            var game = context.Games.Single(x => x.Id == GameId);
            game.GameState = gameState.ToString();
            if (gameState == GameState.Complete)
            {
                game.IsComplete = true;
                DetermineWinner(GameId);
            }
        }

        private void DetermineWinner(Guid GameId)
        {
            var roundAdapter = new RoundAdapter();
            var roundsForGame = roundAdapter.GetCompletedRoundByGameId(GameId);

            var Team1Wins = roundsForGame.Count(x => x.Result == RoundResult.Team1Won);
            var Team2Wins = roundsForGame.Count(x => x.Result == RoundResult.Team2Won);

            if (Team1Wins > Team2Wins)
            {
                UpdateWinningTeam("Team1", GameId);
            }
            else
            {
                UpdateWinningTeam("Team2", GameId);
            }

        }
    }
}
