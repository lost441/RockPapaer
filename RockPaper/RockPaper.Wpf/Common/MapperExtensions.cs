
namespace RockPaper.Wpf.Common
{
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
    }
}
