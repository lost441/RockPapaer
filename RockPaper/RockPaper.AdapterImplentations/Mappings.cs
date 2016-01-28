// <copyright file="Mappings.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

using Contracts.Providers;

namespace RockPaper.Adapter
{
    using Contracts.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extentiuns Mappings for database objects.
    /// </summary>
    public static class Mappings
    {
        /// <summary>
        /// Maps the specified game.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns></returns>
        public static Game Map(this RockPaper.DataSource.Game game)
        {
            return new Game
            {
                GameState = (GameState)Enum.Parse(typeof(GameState), game.GameState, true),
                Id = game.Id,
                IsComplete = game.IsComplete,
                Team1 = game.Team1 != null ? game.Team1.Map() : null,
                Team2 = game.Team2 != null ? game.Team2.Map() : null,
                WinningTeam = game.WinningTeam,
                IsSimulatedGame = game.IsSimulatedGame,
                CreatedDate = game.CreatedDate
            };
        }

        /// <summary>
        /// Maps the specified game.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns></returns>
        public static IEnumerable<Game> Map(this IEnumerable<RockPaper.DataSource.Game> game)
        {
            return game.Select(Map);
        }

        /// <summary>
        /// Maps the specified round.
        /// </summary>
        /// <param name="round">The round.</param>
        /// <returns></returns>
        public static Round Map(this RockPaper.DataSource.Round round)
        {
            Hand? nullableHand = null;

            return new Round
            {
                Id = round.Id,
                Result = !string.IsNullOrEmpty(round.Result) ? (RoundResult)Enum.Parse(typeof(RoundResult), round.Result, true) : RoundResult.NotComplete,
                SequenceNumber = round.SequenceNumber,
                Team1Hand = !string.IsNullOrEmpty(round.Team1Hand) ? (Hand)Enum.Parse(typeof(Hand), round.Team1Hand, true) : nullableHand,
                Team2Hand = !string.IsNullOrEmpty(round.Team2Hand) ? (Hand)Enum.Parse(typeof(Hand), round.Team2Hand, true) : nullableHand,
                GameId = round.Game.Id
            };
        }

        /// <summary>
        /// Maps the specified round.
        /// </summary>
        /// <param name="round">The round.</param>
        /// <returns></returns>
        public static IEnumerable<Round> Map(this IEnumerable<RockPaper.DataSource.Round> round)
        {
            return round.Select(Map);
        }

        /// <summary>
        /// Maps the specified team.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns></returns>
        public static Team Map(this RockPaper.DataSource.Team team)
        {
            if (team == null)
            {
                return null;
            }

            return new Team
            {
                Id = team.Id,
                TeamName = team.TeamName
            };
        }
    }
}
