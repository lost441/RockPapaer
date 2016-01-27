// <copyright file="GameState.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace Contracts.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Game State.
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// The waiting for players
        /// </summary>
        WaitingForPlayers = 0,

        /// <summary>
        /// The player1 hand
        /// </summary>
        Player1Hand = 1,

        /// <summary>
        /// The player2 hand
        /// </summary>
        Player2Hand = 2,

        /// <summary>
        /// The complete
        /// </summary>
        Complete = 3
    }
}
