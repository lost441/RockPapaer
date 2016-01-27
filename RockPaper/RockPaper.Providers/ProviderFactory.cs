
using Contracts.Providers;

namespace RockPaper.Providers
{
    public static class ProviderFactory
    {
        /// <summary>
        /// Gets the security provider.
        /// </summary>
        /// <returns>Security</returns>
        public static ISecurityProvider GetSecurityProvider()
        {
            return new SecurityProvider();
        }
        
        /// <summary>
        /// Gets the game provider.
        /// </summary>
        /// <returns>The Game provider</returns>
        public static IGameProvider GetGameProvider()
        {
            return new GameProvider();
        }

        /// <summary>
        /// Gets the team provider.
        /// </summary>
        /// <returns>The team provider</returns>
        public static ITeamProvider GetTeamProvider()
        {
            return new TeamProvider();
        }

        /// <summary>
        /// Gets the round provider.
        /// </summary>
        /// <returns>The round provider</returns>
        public static IRoundProvider GetRoundProvider()
        {
            return new RoundProvider();
        }
    }
}
