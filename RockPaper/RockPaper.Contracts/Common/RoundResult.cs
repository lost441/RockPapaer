// <copyright file="RoundResult.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace Contracts.Common
{
    /// <summary>
    /// The Round Result.
    /// </summary>
    public enum RoundResult
    {
        /// <summary>
        /// The not complete
        /// </summary>
        NotComplete = 0,

        /// <summary>
        /// The team1 won
        /// </summary>
        Team1Won = 1,

        /// <summary>
        /// The team2 won
        /// </summary>
        Team2Won = 2,

        /// <summary>
        /// The draw
        /// </summary>
        Draw = 3
    }
}
