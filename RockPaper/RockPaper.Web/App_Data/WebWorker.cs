
namespace RockPaper.Web.App_Data
{
    using System.Web;

    /// <summary>
    /// The Web Worker
    /// </summary>
    public static class WebWorker
    {
        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <returns>The base url of the website</returns>
        public static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;

            var appUrl = (string.IsNullOrEmpty(HttpRuntime.AppDomainAppVirtualPath)
                ? string.Empty
                : HttpRuntime.AppDomainAppVirtualPath);

            var baseAddress = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseAddress;
        }
    }
}