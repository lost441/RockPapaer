// <copyright file="Game.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.DataSource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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
        [Key][Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the state of the game.
        /// </summary>
        /// <value>
        /// The state of the game.
        /// </value>
        public string GameState { get; set; }

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

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is simulated game.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is simulated game; otherwise, <c>false</c>.
        /// </value>
        public bool IsSimulatedGame { get; set; }

        /// <summary>
        /// Gets or sets the team1 identifier.
        /// </summary>
        /// <value>
        /// The team1 identifier.
        /// </value>
        public virtual Team Team1 { get; set; }

        /// <summary>
        /// Gets or sets the team2 identifier.
        /// </summary>  
        /// <value>
        /// The team2 identifier.
        /// </value>
        public virtual Team Team2 { get; set; }

        /// <summary>
        /// Gets or sets the games.
        /// </summary>
        /// <value>
        /// The games.
        /// </value>
        public virtual ICollection<Round> Rounds { get; set; }
    }
}
