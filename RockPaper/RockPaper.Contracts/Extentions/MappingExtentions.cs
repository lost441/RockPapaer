
using RockPaper.Contracts.Providers;

namespace RockPaper.Contracts.Extentions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class MappingExtentions
    {

        /// <summary>
        /// Maps the specified game.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns>THe mapped game</returns>
        public static Api.Game Map(this Game game)
        {
            if (game == null)
            {
                return null;
            }

            game.Team1 = game.Team1 ?? new Team();
            game.Team2 = game.Team2 ?? new Team();

            return new Api.Game
            {
                GameState = game.GameState,
                Id = game.Id,
                IsComplete = game.IsComplete,
                TeamName1 = game.Team1.TeamName,
                TeamName2 = game.Team2.TeamName,
                WinningTeam = game.WinningTeam
            };
        }

        /// <summary>
        /// Maps the specified game.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns></returns>
        public static IEnumerable<Api.Game> Map(this List<Providers.Game> game)
        {
            return game.Select(Map);
        }

        /// <summary>
        /// Maps the specified team.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns></returns>
        public static Api.Team Map(this Providers.Team team)
        {
            if (team == null)
            {
                return null;
            }

            return new Api.Team
            {
                Id = team.Id,
                TeamName = team.TeamName
            };
        }

        /// <summary>
        /// Maps the specified team.
        /// </summary>
        /// <param name="teams">The team.</param>
        /// <returns>Map the team list</returns>
        public static IEnumerable<Api.Team> Map(this List<Providers.Team> teams)
        {
            return teams.Select(Map);
        }
        
        /// <summary>
        /// Maps the specified round.
        /// </summary>
        /// <param name="round">The round.</param>
        /// <returns></returns>
        public static Api.Round Map(this Providers.Round round)
        {
            if (round == null)
            {
                return null;
            }

            return new Api.Round
            {
               Id = round.Id,
               SequenceNumber = round.SequenceNumber,
               GameId = round.GameId,
               Result = round.Result,
               Team1Hand = round.Team1Hand,
               Team2Hand = round.Team2Hand
            };
        }

        /// <summary>
        /// Maps the specified team.
        /// </summary>
        /// <param name="rounds">The team.</param>
        /// <returns>Map the round list</returns>
        public static IEnumerable<Api.Round> Map(this List<Providers.Round> rounds)
        {
            return rounds.Select(Map);
        }

    }
}