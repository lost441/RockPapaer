// <copyright file="TeamProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.Providers
{
    using AdapterImplentations;
    using System;
    using Contracts.Providers;

    /// <summary>
    /// The Team Provider.
    /// </summary>
    public class TeamProvider : ITeamProvider
    {
        /// <summary>
        /// Registers the team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns></returns>
        public Team RegisterTeam(string teamName)
        {
            var adapter = new TeamAdapter();
            var team = adapter.RegisterNewTeam(teamName);
            adapter.SaveChanges();
            return team;
        }

        /// <summary>
        /// Gets the team by identifier.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <returns></returns>
        public Team GetTeamById(Guid teamId)
        {
            var adapter = new TeamAdapter();
            return adapter.GetTeamById(teamId);
        }

        /// <summary>
        /// Gets the name of the team by team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns></returns>
        public Team GetTeamByTeamName(String teamName)
        {
            var adapter = new TeamAdapter();
            return adapter.GetTeamByName(teamName);
        }

    }
}
