
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
    }
}
