// <copyright file="ITeamProvider.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace Contracts.Providers
{
    using System;

    /// <summary>
    /// Interface for Team Provider.
    /// </summary>
    public interface ITeamProvider
    {
        /// <summary>
        /// Gets the team by identifier.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <returns></returns>
        Team GetTeamById(Guid teamId);

         /// <summary>
         /// Registers the team.
         /// </summary>
         /// <param name="teamName">Name of the team.</param>
         /// <returns></returns>
        Team RegisterTeam(string teamName);
    }
}
