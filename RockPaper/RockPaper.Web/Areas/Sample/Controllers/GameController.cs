
namespace RockPaper.Web.Areas.Sample.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Contracts;
    using Contracts.Response;
    using StubData.Builders;
    using Contracts.Exceptions;
    using System.Linq;

    /// <summary>
    /// The Game API
    /// </summary>
    [RoutePrefix("api/sample/games")]
    public class GameController : ApiController, IApiController<Game>
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
            var games = new List<Game>
            {
                new GameBuilder().New().Build(),
                new GameBuilder().InProgress().Build(),
                new GameBuilder().Complete().Build()
            };

            return new ResponseList<Game>(ResultCodeEnum.Success)
            {
                Data = games
            };
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseList<Game> Put(IEnumerable<Game> items)
        {
            return new ResponseList<Game>(ResultCodeEnum.Success)
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
        public ResponseItem<Game> Get(string id)
        {
            if (id.ToLower().Contains("error"))
            {
                return new ResponseItem<Game>(ResultCodeEnum.GeneralFailure)
                {
                    Errors = new List<string>() {"General Error Simulated"}
                };
            }

            if (id.ToLower().Contains("exception"))
            {
                throw new BadRequestException();
            }

            return new ResponseItem<Game>(ResultCodeEnum.Success)
            {
                Data = new GameBuilder().Complete().Build()
            };
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Updated items</returns>
        [Route("{id}")]
        public ResponseItem<Game> Put(string id, Game item)
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

        [HttpGet]
        [Route("")]
        public ResponseItem<bool> IsItMyTurn(string gameId, string teamId)
        {
            return new ResponseItem<bool>(ResultCodeEnum.Success)
            {
                Data = true
            };
        }

        [HttpGet]
        [Route("")]
        public ResponseList<Game> Get(int? numberOfGames = null)
        {
            var games = new List<Game>
            {
                new GameBuilder().New().Build(),
                new GameBuilder().InProgress().Build(),
                new GameBuilder().Complete().Build()
            };

            return new ResponseList<Game>(ResultCodeEnum.Success)
            {
                Data = numberOfGames == null ? games.Take(numberOfGames.Value) : games
            };
        }
    }
}
