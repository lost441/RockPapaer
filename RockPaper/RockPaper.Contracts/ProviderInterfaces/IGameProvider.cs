// <copyright file="IGameProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.Contracts
{
    using RockPaper.Contracts.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IGameProvider
    {
        /// <summary>
        /// Finds a game.
        /// </summary>
        /// <param name="TeamId">The team identifier.</param>
        /// <returns></returns>
        Guid FindAGame(Guid TeamId);

        /// <summary>
        /// Gets the state of the game.
        /// </summary>
        /// <param name="GameId">The game identifier.</param>
        /// <returns></returns>
        GameState GetGameState(Guid GameId);

        /// <summary>
        /// Determines the winner.
        /// </summary>
        /// <param name="GameId">The game identifier.</param>
        void GameProcesssing(Guid GameId);
    }
}
