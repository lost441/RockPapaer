
namespace RockPaper.Wpf.Adapters
{
    using System;
    using System.Collections.Generic;
    using RockPaper.Wpf.Common;
    using RockPaper.Wpf.Models;

    /// <summary>
    /// WCF implementation of adapter.
    /// </summary>
    class WcfAdapter : IAdapter
    {
        /// <summary>
        /// The client
        /// </summary>
        private readonly RockPaperServiceReference.RockPaperServiceClient client = new RockPaperServiceReference.RockPaperServiceClient();

        /// <summary>
        /// Gets the next available game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="useSimulator">The use simulator.</param>
        /// <returns>
        /// Game identifier
        /// </returns>
        public Result<Guid> GetNextAvailableGame(Guid teamId, bool? useSimulator)
        {
            var result = client.GetNextAvailableGame(teamId, useSimulator);
            return new Result<Guid>
            {
                Data = result.Data,
                IsSuccessfull = result.IsSuccessfull,
                Errors = string.Join(", ", result.Errors)
            };
        }

        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>
        /// A bool indicating if its the teams turn.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Result<bool> IsItMyTurn(Guid gameId, Guid teamId)
        {
            var result = client.IsItMyTurn(gameId, teamId);
            return new Result<bool>
            {
                Data = result.Data,
                IsSuccessfull = result.IsSuccessfull,
                Errors = string.Join(", ", result.Errors)
            };
        }

        /// <summary>
        /// Plays the hand.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="hand">The hand.</param>
        /// <returns>
        /// The outcome
        /// </returns>
        public Result<OperationOutcome> PlayHand(Guid gameId, Guid teamId, Hand hand)
        {
            var result = client.PlayHand(gameId, teamId, (RockPaperServiceReference.Hand) hand);
            return new Result<OperationOutcome>
            {
                Data = result.Data.Map(),
                IsSuccessfull = result.IsSuccessfull,
                Errors = string.Join(", ", result.Errors)
            };
        }

        /// <summary>
        /// Gets the gameby game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>
        /// The game
        /// </returns>
        public Result<Game> GetGamebyGameId(Guid gameId)
        {
            var result = client.GetGamebyGameId(gameId);
            return new Result<Game>
            {
                Data = result.Data.Map(),
                IsSuccessfull = result.IsSuccessfull,
                Errors = string.Join(", ", result.Errors)
            };
        }

        /// <summary>
        /// Registers the team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns>
        /// The team
        /// </returns>
        public Result<Team> RegisterTeam(string teamName)
        {
            var result = client.RegisterTeam(teamName);
            return new Result<Team>
            {
                Data = result.Data.Map(),
                IsSuccessfull = result.IsSuccessfull,
                Errors = string.Join(", ", result.Errors)
            };
        }

        /// <summary>
        /// Gets the name of the team by team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns>
        /// The team
        /// </returns>
        public Result<Team> GetTeamByTeamName(string teamName)
        {
            var result = client.GetTeamByTeamName(teamName);
            return new Result<Team>
            {
                Data = result.Data.Map(),
                IsSuccessfull = result.IsSuccessfull,
                Errors = string.Join(", ", result.Errors)
            };
        }

        /// <summary>
        /// Gets the completed round by game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>
        /// The rounds
        /// </returns>
        public IEnumerable<Round> GetCompletedRoundByGameId(Guid gameId)
        {
            //TODO: Implement WCF call.
            return new List<Round>();
        }
    }
}
