// <copyright file="Team.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace Contracts.Providers
{
    using System;

    /// <summary>
    /// The Team.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>
        /// The team.
        /// </value>
        public string TeamName { get; set; }
    }
}
