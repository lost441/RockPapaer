
namespace RockPaper.Web.Areas.V01.Controllers
{
    using System.Web.Http.Description;
    using Contracts.Exceptions;
    using Contracts.Response;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Contracts.Extentions;

    /// <summary>
    /// Team V01 Controller
    /// </summary>
    [RoutePrefix("api/V01/teams")]
    public class TeamV01Controller : ApiController, IApiController<Contracts.Api.Team>
    {
        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The added item</returns>
        [Route("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ResponseItem<Contracts.Api.Team> Post(Contracts.Api.Team resource)
        {
            var provider = new TeamProvider();

            var team = provider.RegisterTeam(resource.TeamName);

            return new ResponseItem<Contracts.Api.Team>(ResultCodeEnum.Success)
            {
                Data = team.Map()
            };
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        //[Route("")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //public ResponseList<Contracts.Api.Team> Get()
        //{
        //    throw new MethodNotAllowedException();
        //}

        /// <summary>
        /// Gets a list of teams by name
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns>List of teams</returns>
        [Route("")]
        public ResponseList<Contracts.Api.Team> Get(string teamName = null)
        {
            var teamProvider = new TeamProvider();
            var team = teamProvider.GetTeamByTeamName(teamName);

            return new ResponseList<Contracts.Api.Team>(ResultCodeEnum.Success)
            {
                Data = new List<Contracts.Api.Team> { team.Map() }
            };

        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Updated items</returns>
        [Route("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ResponseList<Contracts.Api.Team> Put(IEnumerable<Contracts.Api.Team> items)
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns>Delete success</returns>
        [Route("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ResponseItem<bool> Delete()
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Get a team by ID
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The team</returns>
        [Route("{id}")]
        public ResponseItem<Contracts.Api.Team> Get(Guid id)
        {
            if (id == null)
            {
                throw new BadRequestException();
            }
           
            var provider = new TeamProvider();
            var team = provider.GetTeamById(id);

            return new ResponseItem<Contracts.Api.Team>(ResultCodeEnum.Success)
            {
                Data = team.Map()
            };
        }

        /// <summary>
        /// Puts the specified item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns>The updated item</returns>
        [Route("{id}")]
        public ResponseItem<Contracts.Api.Team> Put(Guid id, Contracts.Api.Team item)
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Update a specific team
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Updated team</returns>
        [Route("")]
        public ResponseItem<Contracts.Api.Team> Put(Contracts.Api.Team item)
        {
            var provider = new TeamProvider();

           var team = provider.RegisterTeam(item.TeamName);

           return new ResponseItem<Contracts.Api.Team>(ResultCodeEnum.Success)
           {
               Data = team.Map()
           };
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete success</returns>
        [Route("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ResponseItem<bool> Delete(Guid id)
        {
            throw new MethodNotAllowedException();
        }
    }
}
