// <copyright file="GameV01Controller.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.Web.Areas.V01.Controllers
{
    using Contracts.Exceptions;
    using Contracts.Response;
    using RockPaper.Contracts.Providers;
    using RockPaper.Providers;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// The Game API
    /// </summary>
    [RoutePrefix("api/V01/rounds")]
    public class RoundV01Controller : ApiController, IApiController<Round>
    {
        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The added item</returns>
        [Route("")]
        public ResponseItem<Round> Post(Round resource)
        {
            throw new UnAuthorizedException();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [Route("")]
        public ResponseList<Round> Get()
        {
            throw new UnAuthorizedException();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [Route("")]
        public ResponseList<Round> Get([FromBody]RockPaper.Contracts.Api.Game game)
        {
            if (game == null)
            {
                throw new UnauthorizedAccessException();
            }

            var provider = new RoundProvider();
            var rounds = provider.GetCompletedRoundByGameId(game.Id);

            return new ResponseList<Round>()
            {
                Data = rounds
            };
        }


        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseList<Round> Put(IEnumerable<Round> items)
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
        public ResponseItem<Round> Get(Guid id)
        {
            throw new UnAuthorizedException();
        }

        [Route("{id}")]
        public ResponseItem<Round> Put(Guid id, Round item)
        {
            throw new UnAuthorizedException();
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseItem<Round> Put(Round item)
        {
            throw new UnAuthorizedException();
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
