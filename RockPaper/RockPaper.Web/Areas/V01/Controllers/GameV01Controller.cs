
using RockPaper.Contracts.Providers;

namespace RockPaper.Web.Areas.V01.Controllers
{
    using System.Collections.Generic;
    using RockPaper.Web.Exentions;
    using System.Web.Http;
    using Contracts;
    using Contracts.Response;
    using StubData.Builders;
    using Contracts.Exceptions;
    using RockPaper.Providers;
    using RockPaper.Contracts.Providers;
    using System;

    /// <summary>
    /// The Game API
    /// </summary>
    [RoutePrefix("api/V01/games")]
    public class GameV01Controller : ApiController, IApiController<Game>
    {
        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The added item</returns>
        [Route("")]
        public ResponseItem<Game> Post(Game resource)
        {
            return new ResponseItem<Game>(ResultCodeEnum.Success)
            {
                Data = resource
            };
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [Route("")]
        public ResponseList<Game> Get()
        {
            throw new UnAuthorizedException();
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseList<Game> Put(IEnumerable<Game> items)
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
        public ResponseItem<RockPaper.Contracts.Api.Game> Get(string id)
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

            return new ResponseItem<RockPaper.Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = game
            };
        }

        [Route("{id}")]
        public ResponseItem<Game> Put(string id, Game item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseItem<Game> Put(Game item)
        {
            return new ResponseItem<Game>(ResultCodeEnum.Success)
            {
                Data = item
            };
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete success</returns>
        [Route("{id}")]
        public ResponseItem<bool> Delete(string id)
        {
            return new ResponseItem<bool>(ResultCodeEnum.Success)
            {
                Data = true
            };
        }
    }
}
