// <copyright file="IRoundAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.Adapter
{
    using Contracts.Common;
    using System;
    using System.Collections.Generic;
    using Contracts.Providers;

    /// <summary>
    /// The round Interface.
    /// </summary>
    public interface IRoundAdapter
    {
        /// <summary>
        /// Creates the round.
        /// </summary>
        /// <param name="round">The round.</param>
        /// <returns></returns>
        Round CreateRound(Round round);

        /// <summary>
        /// Updates the round.
        /// </summary>
        /// <param name="round">The round.</param>
        /// <returns></returns>
        Round UpdateRound(Round round);

        /// <summary>
        /// Gets the round by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IEnumerable<Round> GetCompletedRoundByGameId(Guid id);

        /// <summary>
        /// Updates the team1 hand.
        /// </summary>
        /// <param name="roundId">The round identifier.</param>
        /// <param name="hand">The hand.</param>
        /// <returns></returns>
        Round UpdateTeam1Hand(Guid roundId, Hand hand);

        /// <summary>
        /// Updates the team2 hand.
        /// </summary>
        /// <param name="roundId">The round identifier.</param>
        /// <param name="hand">The hand.</param>
        /// <returns></returns>
       Round UpdateTeam2Hand(Guid roundId, Hand hand);

       /// <summary>
       /// Gets the new round number.
       /// </summary>
       /// <param name="gameId">The game identifier.</param>
       /// <returns></returns>
       int GetNextRoundNumber(Guid gameId);

       /// <summary>
       /// Gets the round for player two.
       /// </summary>
       /// <param name="gameId">The game identifier.</param>
       /// <returns></returns>
       Round GetRoundForPlayerTwo(Guid gameId);
        
       /// <summary>
       /// Saves the changes.
       /// </summary>
        void SaveChanges();
    }
}
