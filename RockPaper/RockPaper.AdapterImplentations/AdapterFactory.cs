
namespace RockPaper.AdapterImplentations
{
    using Adapter;

    /// <summary>
    /// The Adapter Factory
    /// </summary>
    public static class AdapterFactory
    {
        /// <summary>
        /// Gets the game adapter.
        /// </summary>
        /// <returns></returns>
        public static IGameAdapter GetGameAdapter()
        {
            return new GameAdapter();
        }

        /// <summary>
        /// Gets the team adapter.
        /// </summary>
        /// <returns></returns>
        public static ITeamAdapter GetTeamAdapter()
        {
            return new TeamAdapter();
        }

        /// <summary>
        /// Gets the round adapter.
        /// </summary>
        /// <returns></returns>
        public static IRoundAdapter GetRoundAdapter()
        {
            return new RoundAdapter();
        }
    }
}
