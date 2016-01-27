// <copyright file="Game.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace Contracts.Api
{
    using System;
    using Common;

    /// <summary>
    /// The Game class. 
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the team1 identifier.
        /// </summary>
        /// <value>
        /// The team1 identifier.
        /// </value>
        public string TeamName1 { get; set; }

        /// <summary>
        /// Gets or sets the team2 identifier.
        /// </summary>
        /// <value>
        /// The team2 identifier.
        /// </value>
        public string TeamName2 { get; set; }

        /// <summary>
        /// Gets or sets the state of the game.
        /// </summary>
        /// <value>
        /// The state of the game.
        /// </value>
        public GameState GameState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Gets or sets the winning team.
        /// </summary>
        /// <value>
        /// The winning team.
        /// </value>
        public string WinningTeam { get; set; }
    }
}
