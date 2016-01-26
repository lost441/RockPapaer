// <copyright file="TeamProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

using RockPaper.Contracts.Providers;

namespace RockPaper.Providers
{
    using RockPaper.AdapterImplentations;
    using RockPaper.Contracts;
    using RockPaper.Contracts.ProviderInterfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Team Provider.
    /// </summary>
    public class TeamProvider : ITeamProvider
    {
        /// <summary>
        /// Registers the team.
        /// </summary>
        /// <param name="TeamName">Name of the team.</param>
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
        /// <param name="TeamId">The team identifier.</param>
        /// <returns></returns>
        public Team GetTeamById(Guid TeamId)
        {
            var adapter = new TeamAdapter();
            return adapter.GetTeamById(TeamId);
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
