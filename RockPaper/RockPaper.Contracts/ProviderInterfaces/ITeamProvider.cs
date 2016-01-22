// <copyright file="ITeamProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.Contracts.ProviderInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// Interface for Team Provider.
    /// </summary>
    public interface ITeamProvider
    {
        /// <summary>
        /// Gets the team by identifier.
        /// </summary>
        /// <param name="TeamId">The team identifier.</param>
        /// <returns></returns>
        Team GetTeamById(Guid TeamId);

         /// <summary>
         /// Registers the team.
         /// </summary>
         /// <param name="TeamName">Name of the team.</param>
         /// <returns></returns>
        Team RegisterTeam(string TeamName);
    }
}
