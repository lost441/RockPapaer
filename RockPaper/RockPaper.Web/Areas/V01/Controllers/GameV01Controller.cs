// <copyright file="GameV01Controller.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace RockPaper.Web.Areas.V01.Controllers
{
    using Contracts.Exceptions;
    using Contracts.Response;
    using Providers;
    using Contracts.Extentions;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Contracts.Common;

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
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [Route("")]
        public ResponseList<Contracts.Api.Game> Get(bool? isActive = false, Guid? teamId = null, bool playAgainstSimulator = false)
        {
            var isActiveJoinedWithTeamId = ((isActive.HasValue && isActive.Value) || teamId.HasValue);

            if (isActiveJoinedWithTeamId && (!isActive.HasValue || !teamId.HasValue))
            {
                throw new BadRequestException();
            }

            if (isActive.HasValue && !isActive.Value && !teamId.HasValue)
            {
                throw new NotImplementedException("Have not yet implimented fetching all games without active filter");
            }

            var provider = new GameProvider();
            var gameId = provider.GetNextAvailableGame(teamId.Value, playAgainstSimulator);
            var game = provider.GetGameById(gameId).Map();

            return new ResponseList<Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = new List<Contracts.Api.Game>() { game }
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
        public ResponseItem<Contracts.Api.Game> Get(Guid id)
        {
            if (id == null)
            {
                throw new BadRequestException();
            }
            
            var provider = new GameProvider();
            var game = provider.GetGameById(id).Map();
            return new ResponseItem<Contracts.Api.Game>(ResultCodeEnum.Success)
            {
                Data = game
            };
        }

        [Route("{id}")]
        public ResponseItem<Contracts.Api.Game> Put(Guid id, Contracts.Api.Game item)
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
        public ResponseItem<bool> Delete(Guid id)
        {
            throw new MethodNotAllowedException();
        }

        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns></returns>
        [Route("")]
        public ResponseItem<bool> IsItMyTurn(Guid gameId, Guid teamId)
        {
            var gameProvider = new GameProvider();
            var result = gameProvider.IsItMyTurn(gameId, teamId);
            
            return new ResponseItem<bool>(ResultCodeEnum.Success)
            {
                Data = result
            };
        }

        /// <summary>
        /// Plays the hand.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="hand">The hand.</param>
        /// <returns></returns>
        [Route("")]
        public ResponseItem<bool> PlayHand(Guid gameId, Guid teamId, Hand hand)
        {
            var roundProvider = new RoundProvider();
            var outcome = roundProvider.SumbitHand(hand, teamId, gameId);

            return new ResponseItem<bool>(ResultCodeEnum.Success)
            {
                Data = outcome.Result
            };
        }
    }
}
