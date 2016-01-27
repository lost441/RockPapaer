// <copyright file="IGameProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace Contracts.Providers
{
    using System;

    public interface IGameProvider
    {
        /// <summary>
        /// Finds a game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="playAgainstSimulator">if set to <c>true</c> [play against simulator].</param>
        /// <returns>Available game</returns>
        Guid GetNextAvailableGame(Guid teamId, bool playAgainstSimulator = false);

        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>A bool indicating if its the teams turn.</returns>
        bool IsItMyTurn(Guid gameId, Guid teamId);

        /// <summary>
        /// Determines the winner.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        void CompleteRound(Guid gameId);


        /// <summary>
        /// Gets the game by identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        Game GetGameById(Guid gameId);
    }
}
