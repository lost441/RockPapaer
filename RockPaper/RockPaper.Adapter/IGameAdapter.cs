// <copyright file="IGameAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

using RockPaper.Contracts.Providers;

namespace RockPaper.Adapter
{
    using RockPaper.Contracts;
    using RockPaper.Contracts.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Game Interface.
    /// </summary>
    public interface IGameAdapter
    {
        /// <summary>
        /// Gets the game by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Game GetGameById(Guid Id);

        /// <summary>
        /// Gets all games.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Game> GetAllGames();

        /// <summary>
        /// Joins the existing game.
        /// </summary>
        /// <param name="Team">The team.</param>
        /// <param name="GameId">The game identifier.</param>
        /// <returns></returns>
        Game JoinExistingGame(Team Team, Guid GameId);

        /// <summary>
        /// Regsiters the new game.
        /// </summary>
        /// <returns></returns>
        Game RegisiterNewGame();

        /// <summary>
        /// Updates the game.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns></returns>
        Game UpdateGame(Game game);

        /// <summary>
        /// Updates the state of the game.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        void UpdateGameState(GameState gameState, Guid GameId);

        /// <summary>
        /// Updates the winning team.
        /// </summary>
        /// <param name="winningTeam">The winning team.</param>
        /// <param name="GameId">The game identifier.</param>
        void UpdateWinningTeam(string winningTeam, Guid GameId);

        /// <summary>
        /// Gets the state of the game.
        /// </summary>
        /// <param name="GameId">The game identifier.</param>
        /// <returns></returns>
        GameState GetGameState(Guid GameId);

        /// <summary>
        /// Gets the games for dashbaord.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Contracts.Providers.Game> GetGamesForDashbaord();
    }
}
