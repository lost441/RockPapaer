
namespace RockPaper.Web.Areas.Sample.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Contracts.Response;
    using StubData.Builders;
    using Contracts.Providers;
    using Contracts.Exceptions;
    using Contracts.Extentions;

    /// <summary>
    /// The Game API
    /// </summary>
    [RoutePrefix("api/sample/games")]
    public class GamesSampleController : ApiController
    {
        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The added item</returns>
        [Route("")]
        public ResponseItem<Contracts.Api.Game> Post(Contracts.Api.Game resource)
        {
            return new ResponseItem<Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = resource
            };
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [Route("")]
        public ResponseList<Contracts.Api.Game> Get()
        {
            var games = new List<Game>
            {
                new GameBuilder().New().Build(),
                new GameBuilder().InProgress().Build(),
                new GameBuilder().Complete().Build()
            };

            return new ResponseList<Contracts.Api.Game>(ResultCodeEnum.Success)
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
        public ResponseList<Contracts.Api.Game> Put(IEnumerable<Contracts.Api.Game> items)
        {
            return new ResponseList<Contracts.Api.Game>(ResultCodeEnum.Success)
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
        public ResponseItem<Contracts.Api.Game> Get(string id)
        {
            if (id.ToLower().Contains("error"))
            {
                return new ResponseItem<Contracts.Api.Game>(ResultCodeEnum.GeneralFailure)
                {
                    Errors = new List<string>() {"General Error Simulated"}
                };
            }

            if (id.ToLower().Contains("exception"))
            {
                throw new BadRequestException();
            }


            return new ResponseItem<Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = new GameBuilder().Complete().Build().Map()
            };
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns>THe added item</returns>
        [Route("{id}")]
        public ResponseItem<Contracts.Api.Game> Put(string id, Contracts.Api.Game item)
        {
            if (id.ToLower().Contains("error"))
            {
                return new ResponseItem<Contracts.Api.Game>(ResultCodeEnum.GeneralFailure)
                {
                    Errors = new List<string>() { "General Error Simulated" }
                };
            }

            if (id.ToLower().Contains("exception"))
            {
                throw new BadRequestException();
            }

            return new ResponseItem<Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = item
            };
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseItem<Contracts.Api.Game> Put(Contracts.Api.Game item)
        {
            return new ResponseItem<Contracts.Api.Game>(ResultCodeEnum.Success)
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
