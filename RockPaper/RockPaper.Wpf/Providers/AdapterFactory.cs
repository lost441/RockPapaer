
namespace RockPaper.Wpf.Providers
{
    using RockPaper.Wpf.Adapters;

    /// <summary>
    /// Adapter factory class.
    /// </summary>
    public static class AdapterFactory
    {
        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <param name="isRestCall">if set to <c>true</c> [is rest call].</param>
        /// <returns>The adapter</returns>
        public static IAdapter GetAdapter(bool isRestCall)
        {
            if (isRestCall)
            {
                return new RestAdapter();
            }

            return new WcfAdapter();
        }
    }
}
