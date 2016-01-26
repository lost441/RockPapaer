using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaper.Web.Exentions
{
    public static class MappingExtentions
    {

        /// <summary>
        /// Maps the specified game.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns></returns>
        public static RockPaper.Contracts.Api.Game Map(this RockPaper.Contracts.Providers.Game game)
        {
            if (game == null)
            {
                return null;
            }

            return new RockPaper.Contracts.Api.Game
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
        public static IEnumerable<RockPaper.Contracts.Api.Game> Map(this List<RockPaper.Contracts.Providers.Game> game)
        {
            return game.Select(Map);
        }
    }
}