
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
        /// <returns></returns>
        public static Api.Game Map(this Providers.Game game)
        {
            if (game == null)
            {
                return null;
            }

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
    }
}