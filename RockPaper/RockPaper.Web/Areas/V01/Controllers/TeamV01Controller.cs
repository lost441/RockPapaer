
namespace RockPaper.Web.Areas.V01.Controllers
{
    using RockPaper.Contracts.Exceptions;
    using RockPaper.Contracts.Providers;
    using RockPaper.Contracts.Response;
    using RockPaper.Providers;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    [RoutePrefix("api/V01/teams")]
    public class TeamV01Controller : ApiController, IApiController<Team>
    {
        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The added item</returns>
        [Route("")]
        public ResponseItem<Team> Post(Team resource)
        {
            throw new UnAuthorizedException();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [Route("")]
        public ResponseList<Team> Get()
        {
            throw new UnauthorizedAccessException();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [Route("")]
        public ResponseList<Team> Get(string teamName = null)
        {
            var teamProvider = new TeamProvider();
            var team = teamProvider.GetTeamByTeamName(teamName);

            return new ResponseList<Team>(ResultCodeEnum.Success)
            {
                Data = new List<Team>() { team }
            };

        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseList<Team> Put(IEnumerable<Team> items)
        {
            throw new UnAuthorizedException();
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns>Delete success</returns>
        [Route("")]
        public ResponseItem<bool> Delete()
        {
            throw new UnAuthorizedException();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// All items
        /// </returns>
        [Route("{id}")]
        public ResponseItem<Team> Get(Guid id)
        {
            if (id == null)
            {
                throw new BadRequestException();
            }
           
            var provider = new TeamProvider();
            var team = provider.GetTeamById(id);

            return new ResponseItem<Team>(ResultCodeEnum.Success)
            {
                Data = team
            };
        }

        /// <summary>
        /// Puts the specified item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns>
        /// The updated item
        /// </returns>
        /// <exception cref="UnAuthorizedException"></exception>
        [Route("{id}")]
        public ResponseItem<Team> Put(Guid id, Team item)
        {
            throw new UnAuthorizedException();
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseItem<Team> Put(Team item)
        {
            var provider = new TeamProvider();

           var team = provider.RegisterTeam(item.TeamName);

           return new ResponseItem<Team>(ResultCodeEnum.Success)
           {
               Data = team
           };

        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete success</returns>
        [Route("{id}")]
        public ResponseItem<bool> Delete(Guid id)
        {
            throw new UnAuthorizedException();
        }
    }
}
