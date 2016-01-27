// <copyright file="IRoundProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace Contracts.Providers
{
    using System;
    using System.Collections.Generic;
    using Common;

    public interface IRoundProvider
    {
        /// <summary>
        /// Sumbits the hand.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>Opperation outcome</returns>
        OperationOutcome SumbitHand(Hand hand, Guid teamId, Guid gameId);

        /// <summary>
        /// Gets the completed round by game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        IEnumerable<Round> GetCompletedRoundByGameId(Guid gameId);

        /// <summary>
        /// Sumbits the simulated hand.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns>Opepration outcome</returns>
        OperationOutcome SumbitSimulatedHand(Game game);
    }
}
