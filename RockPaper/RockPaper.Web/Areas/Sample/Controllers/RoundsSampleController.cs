
namespace RockPaper.Web.Areas.Sample.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Contracts.Response;
    using StubData.Builders;
    using Contracts.Providers;
    using Contracts.Exceptions;
    using Contracts.Extentions;
    using System;
    using Contracts.Common;

    /// <summary>
    /// The Game API
    /// </summary>
    [RoutePrefix("api/sample/rounds")]
    public class RoundsSampleController : ApiController
    {
        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The added item</returns>
        [Route("")]
        public ResponseItem<Contracts.Api.Round> Post(Contracts.Api.Round resource)
        {
            return new ResponseItem<Contracts.Api.Round>(ResultCodeEnum.Success)
            {
                Data = resource
            };
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [Route("")]
        public ResponseList<Contracts.Api.Round> Get()
        {
            var gameId = Guid.NewGuid();

            var teams = new List<Round>
            {
                new RoundBuilder().CompleteRound(1, gameId).Build(),
                new RoundBuilder().DefaultRound(2, gameId).SetHandOne(Hand.Paper).Build()
            };

            return new ResponseList<Contracts.Api.Round>(ResultCodeEnum.Success)
            {
                Data = teams.Map()
            };
        }

        /// <summary>
        /// Puts the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Updated items</returns>
        [Route("")]
        public ResponseList<Contracts.Api.Round> Put(IEnumerable<Contracts.Api.Round> items)
        {
            return new ResponseList<Contracts.Api.Round>(ResultCodeEnum.Success)
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
        public ResponseItem<Contracts.Api.Round> Get(string id)
        {
            if (id.ToLower().Contains("error"))
            {
                return new ResponseItem<Contracts.Api.Round>(ResultCodeEnum.GeneralFailure)
                {
                    Errors = new List<string>() {"General Error Simulated"}
                };
            }

            if (id.ToLower().Contains("exception"))
            {
                throw new BadRequestException();
            }


            return new ResponseItem<Contracts.Api.Round>(ResultCodeEnum.Success)
            {
                Data = new RoundBuilder().Build().Map()
            };
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns>THe added item</returns>
        [Route("{id}")]
        public ResponseItem<Contracts.Api.Round> Put(string id, Contracts.Api.Round item)
        {
            if (id.ToLower().Contains("error"))
            {
                return new ResponseItem<Contracts.Api.Round>(ResultCodeEnum.GeneralFailure)
                {
                    Errors = new List<string>() { "General Error Simulated" }
                };
            }

            if (id.ToLower().Contains("exception"))
            {
                throw new BadRequestException();
            }

            return new ResponseItem<Contracts.Api.Round>(ResultCodeEnum.Success)
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
        public ResponseItem<Contracts.Api.Team> Put(Contracts.Api.Team item)
        {
            return new ResponseItem<Contracts.Api.Team>(ResultCodeEnum.Success)
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
