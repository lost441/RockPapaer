// <copyright file="ITeamAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.Adapter
{
    using RockPaper.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Team Interface.
    /// </summary>
    public interface ITeamAdapter
    {
        /// <summary>
        /// Registers the new team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns></returns>
        RockPaper.Contracts.Team RegisterNewTeam(string teamName);

        /// <summary>
        /// Gets the team by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        RockPaper.Contracts.Team GetTeamById(Guid Id);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
    }
}   
