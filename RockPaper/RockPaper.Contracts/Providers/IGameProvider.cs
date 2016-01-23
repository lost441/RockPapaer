// <copyright file="IGameProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.Contracts.Providers
{
    using System;

    public interface IGameProvider
    {
        /// <summary>
        /// Finds a game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <returns></returns>
        Guid GetNextAvailableGame(Guid teamId);

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
    }
}
