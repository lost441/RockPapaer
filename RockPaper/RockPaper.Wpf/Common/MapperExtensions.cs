
namespace RockPaper.Wpf.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using RockPaper.Wpf.Models;

    /// <summary>
    /// Mapper Extensions
    /// </summary>
    public static class MapperExtensions
    {
        /// <summary>
        /// Maps the specified original.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <returns>The game</returns>
        public static Game Map(this RockPaperServiceReference.Game original)
        {
            return original == null
                ? null
                : new Game
                {
                    Id = original.Id,
                    GameState = original.GameState.ToString(),
                    IsComplete = original.IsComplete,
                    TeamName1 = original.TeamName1,
                    TeamName2 = original.TeamName2,
                    WinningTeam = original.WinningTeam
                };
        }

        /// <summary>
        /// Maps the specified original.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <returns>The team</returns>
        public static Team Map(this RockPaperServiceReference.Team original)
        {
            return original == null
                ? null
                : new Team
                {
                    Id = original.Id,
                    TeamName = original.TeamName
                };
        }

        /// <summary>
        /// Maps the specified original.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <returns>The outcome</returns>
        public static OperationOutcome Map(this RockPaperServiceReference.OperationOutcome original)
        {
            return original == null
                ? null
                : new OperationOutcome
                {
                    Result = original.Result,
                    Error = original.Error
                };
        }

        public static Round Map(this RockPaperServiceReference.Round original)
        {
            return original == null
                ? null
                : new Round
                {
                    GameId = original.GameId,
                    Id = original.Id,
                    Result = original.Result.ToString(),
                    Team1Hand = original.Team1Hand.ToString(),
                    Team2Hand = original.Team2Hand.ToString(),
                    SequenceNumber = original.SequenceNumber
                };
        }

        public static IEnumerable<Round> Map(this IEnumerable<RockPaperServiceReference.Round> originals)
        {
            return originals.Select(Map);
        }

        public static Round Map(this RoundFacade original)
        {
            return original == null
                ? null
                : new Round
                {
                    GameId = original.GameId,
                    Id = original.Id,
                    Result = original.Result.ToString(),
                    Team1Hand = original.Team1Hand.ToString(),
                    Team2Hand = original.Team2Hand.ToString(),
                    SequenceNumber = original.SequenceNumber
                };
        }

        public static IEnumerable<Round> Map(this IEnumerable<RoundFacade> originals)
        {
            return originals.Select(Map);
        } 
    }
}
