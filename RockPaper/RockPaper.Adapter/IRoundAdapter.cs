// <copyright file="IRoundAdapter.cs" company="PayM8">
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
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IEnumerable<Round> GetCompletedRoundByGameId(Guid Id);

        /// <summary>
        /// Updates the team1 hand.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns></returns>
        Round UpdateTeam1Hand(Guid RoundId, Hand hand);

        /// <summary>
        /// Updates the team2 hand.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns></returns>
       Round UpdateTeam2Hand(Guid RoundId, Hand hand);

       /// <summary>
       /// Gets the new round number.
       /// </summary>
       /// <param name="GameId">The game identifier.</param>
       /// <returns></returns>
       int GetNextRoundNumber(Guid GameId);

        /// <summary>
        /// Gets the round for player two.
        /// </summary>
        /// <param name="GameId">The game identifier.</param>
        /// <returns></returns>
       Round GetRoundForPlayerTwo(Guid GameId);

      
    
    }
}
