// <copyright file="IRockPaperService.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.Services.Games
{
    using System;
    using System.ServiceModel;
    using Contracts.Response;
    using RockPaper.Contracts;
    using RockPaper.Contracts.Common;
    using RockPaper.Contracts.Providers;
using System.Collections.Generic;

    [ServiceContract]
    public interface IRockPaperService
    {
        /// <summary>
        /// Finds a game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <returns></returns>
        [OperationContract]
        ResponseItem<Guid> GetNextAvailableGame(Guid teamId, bool? useSimulator);

        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>A bool indicating if its the teams turn.</returns>
        [OperationContract]
        ResponseItem<bool> IsItMyTurn(Guid gameId, Guid teamId);


        /// <summary>
        /// Plays the hand.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="hand">The hand.</param>
        /// <returns></returns>
        [OperationContract]
        ResponseItem<OperationOutcome> PlayHand(Guid gameId, Guid teamId, Hand hand);

        /// <summary>
        /// Gets the gameby game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        [OperationContract]
        ResponseItem<RockPaper.Contracts.Api.Game> GetGamebyGameId(Guid gameId);

        /// <summary>
        /// Registers the team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns></returns>
        [OperationContract]
        ResponseItem<Team> RegisterTeam(string teamName);

        /// <summary>
        /// Gets the name of the team by team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns></returns>
        [OperationContract]
        ResponseItem<Team> GetTeamByTeamName(string teamName);

        /// <summary>
        /// Gets the completed round by game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>List of Rounds.</returns>
        [OperationContract]
        IEnumerable<Round> GetCompletedRoundByGameId(Guid gameId);
    }
}
