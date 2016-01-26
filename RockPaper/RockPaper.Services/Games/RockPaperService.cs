﻿// <copyright file="RockPaperService.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.Services.Games
{
    using System;
    using Contracts.Response;
    using Providers;
    using RockPaper.Contracts;
    using RockPaper.Contracts.Common;
    using RockPaper.Contracts.Providers;
    
    /// <summary>
    /// Dog Service
    /// </summary>
    public class RockPaperService : IRockPaperService
    {
        /// <summary>
        /// Finds a game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>The next available game</returns>
        public ResponseItem<Guid> GetNextAvailableGame(Guid teamId)
        {
            var provider = new GameProvider();
            var gameId = provider.GetNextAvailableGame(teamId);

            return new ResponseItem<Guid>(ResultCodeEnum.Success)
            {
                Data = gameId
            };
        }

        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>A bool indicating if its the teams turn</returns>
        public ResponseItem<bool> IsItMyTurn(Guid gameId, Guid teamId)
        {
            var provider = new GameProvider();
            var isMyTurn = provider.IsItMyTurn(gameId, teamId);
            
            return new ResponseItem<bool>(ResultCodeEnum.Success)
            {
                Data = isMyTurn
            };
        }

        /// <summary>
        /// Plays the hand.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="hand">The hand.</param>
        /// <returns></returns>
        public ResponseItem<OperationOutcome> PlayHand(Guid gameId, Guid teamId, Hand hand)
        {
            var roundProvider = new RoundProvider();
            var outcome = roundProvider.SumbitHand(hand, teamId, gameId);

            return new ResponseItem<OperationOutcome>(ResultCodeEnum.Success)
            {
                Data = outcome
            };
        }

        /// <summary>
        /// Registers the team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns></returns>
        public ResponseItem<Team> RegisterTeam(string teamName)
        {
            var provider = new TeamProvider();
            var existingTeam = provider.GetTeamByTeamName(teamName);
            
            if (existingTeam != null)
            {
                return new ResponseItem<Team>(ResultCodeEnum.GeneralFailure)
                {
                    IsSuccessfull = false,
                    Errors = new string[] { "Team already exists. Cannot register a duplicate name." }
                };
            }

            var team = provider.RegisterTeam(teamName);

            return new ResponseItem<Team>(ResultCodeEnum.Success)
            {
                Data = team
            };
        }

        /// <summary>
        /// Gets the name of the team by team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns></returns>
        public ResponseItem<Team> GetTeamByTeamName(string teamName)
        {
            var provider = new TeamProvider();
            var team = provider.GetTeamByTeamName(teamName);

            return new ResponseItem<Team>(ResultCodeEnum.Success)
            {
                Data = team
            };
        }
    }
}
