// <copyright file="TeamAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.AdapterImplentations
{
    using Adapter;
    using DataSource;
    using System;
    using System.Linq;
  
    /// <summary>
    /// The Team Adapter.
    /// </summary>
    public class TeamAdapter : ITeamAdapter
    {
        /// <summary>
        /// The context
        /// </summary>
        private RockPapercContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamAdapter"/> class.
        /// </summary>
        public TeamAdapter()
        {
            context = new RockPapercContext();
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO: Add logging.
            }
        }

        /// <summary>
        /// Registers the new team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns></returns>
        public Contracts.Providers.Team RegisterNewTeam(string teamName)
        {
            var dataItemTeam = new DataSource.Team
            {
                Id = Guid.NewGuid(),
                TeamName = teamName
            };

            return context.Team.Add(dataItemTeam).Map();
        }

        /// <summary>
        /// Gets the team by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Contracts.Providers.Team GetTeamById(Guid Id)
        {
            return context.Team.Single(x => x.Id == Id).Map();
        }

        /// <summary>
        /// Gets the name of the team by.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns></returns>
        public Contracts.Providers.Team GetTeamByName(string teamName)
        {
            return context.Team.FirstOrDefault(x => x.TeamName == teamName).Map();
        }
    }
}
