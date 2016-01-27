
namespace RockPaper.Wpf.Providers
{
    using System;
    using System.Collections.Generic;
    using RockPaper.Wpf.Common;
    using RockPaper.Wpf.Models;

    /// <summary>
    /// Game provider class.
    /// </summary>
    public class GameProvider : IGameProvider
    {
        /// <summary>
        /// The is rest call.
        /// </summary>
        private readonly bool isRestCall;
                
        /// <summary>
        /// Initializes a new instance of the <see cref="GameProvider"/> class.
        /// </summary>
        /// <param name="isRestCall">if set to <c>true</c> [is rest call].</param>
        public GameProvider(bool isRestCall)
        {
            this.isRestCall = isRestCall;
        }

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
            var context = AdapterFactory.GetAdapter(this.isRestCall);
            return context.GetNextAvailableGame(teamId, useSimulator);
        }

        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>
        /// A bool indicating if its the teams turn.
        /// </returns>
        public Result<bool> IsItMyTurn(Guid gameId, Guid teamId)
        {
            var context = AdapterFactory.GetAdapter(this.isRestCall);
            return context.IsItMyTurn(gameId, teamId);
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
            var context = AdapterFactory.GetAdapter(this.isRestCall);
            return context.PlayHand(gameId, teamId,  hand);
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
            var context = AdapterFactory.GetAdapter(this.isRestCall);
            return context.GetGamebyGameId(gameId);
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
            var context = AdapterFactory.GetAdapter(this.isRestCall);
            return context.RegisterTeam(teamName);
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
            var context = AdapterFactory.GetAdapter(this.isRestCall);
            return context.GetTeamByTeamName(teamName);
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
            var context = AdapterFactory.GetAdapter(this.isRestCall);
            return context.GetCompletedRoundByGameId(gameId);
        }
    }
}
