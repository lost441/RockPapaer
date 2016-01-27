
namespace RockPaper.Wpf.Adapters
{
    using System;
    using System.Collections.Generic;
    using RockPaper.Wpf.Common;
    using RockPaper.Wpf.Models;

    /// <summary>
    /// Adapter contract.
    /// </summary>
    public interface IAdapter
    {
        /// <summary>
        /// Gets the next available game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="useSimulator">The use simulator.</param>
        /// <returns>
        /// Game identifier
        /// </returns>
        Result<Guid> GetNextAvailableGame(Guid teamId, bool? useSimulator);

        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>A bool indicating if its the teams turn.</returns>
        Result<bool> IsItMyTurn(Guid gameId, Guid teamId);

        /// <summary>
        /// Plays the hand.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="hand">The hand.</param>
        /// <returns>The outcome</returns>
        Result<OperationOutcome> PlayHand(Guid gameId, Guid teamId, Hand hand);

        /// <summary>
        /// Gets the gameby game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>The game</returns>
        Result<Game> GetGamebyGameId(Guid gameId);

        /// <summary>
        /// Registers the team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns>The team</returns>
        Result<Team> RegisterTeam(string teamName);

        /// <summary>
        /// Gets the name of the team by team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns>The team</returns>
        Result<Team> GetTeamByTeamName(string teamName);

        /// <summary>
        /// Gets the completed round by game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>The rounds</returns>
        IEnumerable<Round> GetCompletedRoundByGameId(Guid gameId);
    }
}
