// <copyright file="IGameAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.Adapter
{
    using Contracts.Common;
    using System;
    using System.Collections.Generic;
    using Contracts.Providers;

    /// <summary>
    /// The Game Interface.
    /// </summary>
    public interface IGameAdapter
    {
        /// <summary>
        /// Gets the game by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Game GetGameById(Guid id);

        /// <summary>
        /// Gets all games.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Game> GetAllGames();

        /// <summary>
        /// Joins the existing game.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        Game JoinExistingGame(Team team, Guid gameId);

        /// <summary>
        /// Regsiters the new game.
        /// </summary>
        /// <returns></returns>
        Game RegisiterNewGame();

        /// <summary>
        /// Regsiters the new game.
        /// </summary>
        /// <param name="simulatedTeamName">Name of the simulated team.</param>
        /// <returns>Simulated Game</returns>
        Game RegisiterSimulatorGame(string simulatedTeamName);

        /// <summary>
        /// Updates the game.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns></returns>
        Game UpdateGame(Game game);

        /// <summary>
        /// Updates the state of the game.
        /// </summary>
        /// <param name="gameState">State of the game.</param>
        /// <param name="gameId">The game identifier.</param>
        void UpdateGameState(GameState gameState, Guid gameId);

        /// <summary>
        /// Updates the winning team.
        /// </summary>
        /// <param name="winningTeam">The winning team.</param>
        /// <param name="gameId">The game identifier.</param>
        void UpdateWinningTeam(string winningTeam, Guid gameId);

        /// <summary>
        /// Gets the state of the game.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>The game state</returns>
        GameState GetGameState(Guid gameId);

        /// <summary>
        /// Gets the games for dashbaord.
        /// </summary>
        /// <param name="numberOfGames">The number of games.</param>
        /// <returns>Dashboard games</returns>
        IEnumerable<Game> GetGamesForDashbaord(int numberOfGames);

        /// <summary>
        /// Finds the available game.
        /// </summary>
        /// <returns></returns>
        Game FindAvailableGame();

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
    }
}
