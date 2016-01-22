// <copyright file="Team.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.DataSource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
        [Key]
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
