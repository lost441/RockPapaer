
using RockPaper.Contracts.Providers;

namespace RockPaper.Web.Areas.Sample.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Contracts;
    using Contracts.Response;
    using StubData.Builders;
    using Contracts.Exceptions;
    using RockPaper.Web.Exentions;
    using System.Linq;

    /// <summary>
    /// The Game API
    /// </summary>
    [RoutePrefix("api/sample/games")]
    public class GameSampleController : ApiController, IApiController<RockPaper.Contracts.Api.Game>
    {
        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The added item</returns>
        [Route("")]
        public ResponseItem<RockPaper.Contracts.Api.Game> Post(RockPaper.Contracts.Api.Game resource)
        {
            return new ResponseItem<RockPaper.Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = resource
            };
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [Route("")]
        public ResponseList<RockPaper.Contracts.Api.Game> Get()
        {
            var games = new List<Game>
            {
                new GameBuilder().New().Build(),
                new GameBuilder().InProgress().Build(),
                new GameBuilder().Complete().Build()
            };

            return new ResponseList<RockPaper.Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = games.Map()
            };
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseList<RockPaper.Contracts.Api.Game> Put(IEnumerable<RockPaper.Contracts.Api.Game> items)
        {
            return new ResponseList<RockPaper.Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = items
            };
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns>Delete success</returns>
        [Route("")]
        public ResponseItem<bool> Delete()
        {
            return new ResponseItem<bool>(ResultCodeEnum.Success)
            {
                Data = true
            };
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>All items</returns>
        [Route("{id}")]
        public ResponseItem<RockPaper.Contracts.Api.Game> Get(string id)
        {
            if (id.ToLower().Contains("error"))
            {
                return new ResponseItem<RockPaper.Contracts.Api.Game>(ResultCodeEnum.GeneralFailure)
                {
                    Errors = new List<string>() {"General Error Simulated"}
                };
            }

            if (id.ToLower().Contains("exception"))
            {
                throw new BadRequestException();
            }


            return new ResponseItem<RockPaper.Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = new GameBuilder().Complete().Build().Map()
            };
        }

        [Route("{id}")]
        public ResponseItem<RockPaper.Contracts.Api.Game> Put(string id, RockPaper.Contracts.Api.Game item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseItem<RockPaper.Contracts.Api.Game> Put(RockPaper.Contracts.Api.Game item)
        {
            return new ResponseItem<RockPaper.Contracts.Api.Game>(ResultCodeEnum.Success)
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
