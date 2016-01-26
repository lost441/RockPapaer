// <copyright file="ITeamAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.Adapter
{
    using System;
    using Contracts.Providers;

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
        Team RegisterNewTeam(string teamName);

        /// <summary>
        /// Gets the team by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Team GetTeamById(Guid id);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Gets the name of the team by.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns>The team</returns>
        Team GetTeamByName(string teamName);
    }
}   
