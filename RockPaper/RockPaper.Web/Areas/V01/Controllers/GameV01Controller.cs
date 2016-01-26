
namespace RockPaper.Web.Areas.V01.Controllers
{
    using Contracts.Exceptions;
    using Contracts.Response;
    using Providers;
    using Exentions;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// The Game API
    /// </summary>
    [RoutePrefix("api/V01/games")]
    public class GameV01Controller : ApiController, IApiController<Contracts.Api.Game>
    {
        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The added item</returns>
        [Route("")]
        public ResponseItem<Contracts.Api.Game> Post(Contracts.Api.Game resource)
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [Route("")]
        public ResponseList<Contracts.Api.Game> Get()
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseList<Contracts.Api.Game> Put(IEnumerable<Contracts.Api.Game> items)
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns>Delete success</returns>
        [Route("")]
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
        public ResponseItem<Contracts.Api.Game> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new BadRequestException();
            }

            var gameId = new Guid();

            if (!Guid.TryParse(id, out gameId))
            {
                throw new BadRequestException();
            }

            var provider = new GameProvider();
            
            var game = provider.GetGameById(gameId).Map();

            return new ResponseItem<Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = game
            };
        }

        [Route("{id}")]
        public ResponseItem<RockPaper.Contracts.Api.Game> Put(string id, Contracts.Api.Game item)
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseItem<Contracts.Api.Game> Put(Contracts.Api.Game item)
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete success</returns>
        [Route("{id}")]
        public ResponseItem<bool> Delete(string id)
        {
            throw new MethodNotAllowedException();
        }
    }
}
