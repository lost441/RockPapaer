
namespace RockPaper.StubData.Builders
{
    using System;
    using Contracts.Providers;

    public class TeamBuilder : Team
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamBuilder"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public TeamBuilder(Guid? id = null)
        {
            this.Id = id ?? Guid.NewGuid();
        }

        /// <summary>
        /// Alphas the team.
        /// </summary>
        /// <returns>The aplha team</returns>
        public TeamBuilder AlphaTeam()
        {
            this.TeamName = "Alpha Team";

            return this;
        }

        /// <summary>
        /// Alphas the team.
        /// </summary>
        /// <returns>The aplha team</returns>
        public TeamBuilder BravoTeam()
        {
            this.TeamName = "Bravo Team";

            return this;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>The Team</returns>
        public Team Build()
        {
            return new Team
            {
                Id = this.Id,
                TeamName = this.TeamName
            };
        }
    }
}
