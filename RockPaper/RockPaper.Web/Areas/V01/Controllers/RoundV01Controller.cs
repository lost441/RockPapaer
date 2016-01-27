// <copyright file="GameV01Controller.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.Web.Areas.V01.Controllers
{
    using Contracts.Exceptions;
    using Contracts.Response;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Contracts.Extentions;
    using System.Web.Http.Description;

    /// <summary>
    /// The Round API
    /// </summary>
    [RoutePrefix("api/V01/rounds")]
    public class RoundV01Controller : ApiController, IApiController<Contracts.Api.Round>
    {
        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The added item</returns>
        [Route("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ResponseItem<Contracts.Api.Round> Post(Contracts.Api.Round resource)
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        //[Route("")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //public ResponseList<Contracts.Api.Round> Get()
        //{
        //    throw new MethodNotAllowedException();
        //}

        /// <summary>
        /// Get all completed rounds for a specific game
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>List of rounds</returns>
        [Route("")]
        public ResponseList<Contracts.Api.Round> Get(Guid? gameId = null)
        {
            if (gameId == null)
            {
                throw new BadRequestException();
            }

            var provider = new RoundProvider();
            var rounds = provider.GetCompletedRoundByGameId(gameId.Value);

            return new ResponseList<Contracts.Api.Round>()
            {
                Data = rounds.Map()
            };
        }
        
        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Updated items</returns>
        [Route("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ResponseList<Contracts.Api.Round> Put(IEnumerable<Contracts.Api.Round> items)
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
        /// Gets this instance.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// All items
        /// </returns>
        [Route("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ResponseItem<Contracts.Api.Round> Get(Guid id)
        {
            throw new MethodNotAllowedException();
        }

        [Route("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ResponseItem<Contracts.Api.Round> Put(Guid id, Contracts.Api.Round item)
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Updated items</returns>
        [Route("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ResponseItem<Contracts.Api.Round> Put(Contracts.Api.Round item)
        {
            throw new MethodNotAllowedException();
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
