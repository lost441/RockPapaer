
namespace RockPaper.Web.App_Data
{
    using System;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Web.Http.Controllers;

    /// <summary>
    /// The basic authorization filter
    /// </summary>
    public abstract class BasicAuthorizationFilterAttributeBase : StandardAuthorizationFilterAttributeBase
    {
        private const string Scheme = "Basic";

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthorizationFilterAttributeBase"/> class.
        /// </summary>
        /// <param name="issueChallenge">if set to <c>true</c> [issue challenge].</param>
        protected BasicAuthorizationFilterAttributeBase(bool issueChallenge)
            : base(issueChallenge)
        {
        }

        /// <summary>
        /// Gets the authenticated user.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <returns>The authenticated username</returns>
        protected override string GetAuthenticatedUser(HttpActionContext actionContext)
        {
            var auth = actionContext.Request.Headers.Authorization;
            if (auth == null || auth.Scheme != Scheme)
                return null;

            var authHeader = auth.Parameter;
            if (string.IsNullOrEmpty(authHeader))
                return null;

            var authHeaderBytes = Convert.FromBase64String(authHeader);
            var decodedAuthHeader = Encoding.Default.GetString(authHeaderBytes);

            var tokens = decodedAuthHeader.Split(':');

            if (tokens.Length != 2)
                return null;

            return AuthenticateUser(tokens[0], tokens[1])
                ? tokens[0] : null;
        }

        /// <summary>
        /// Determines whether [is password valid] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>If the password is valid</returns>
        protected abstract bool AuthenticateUser(string userName, string password);

        /// <summary>
        /// Gets the unauthorized response header.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <returns>Authentication Header</returns>
        protected override AuthenticationHeaderValue GetUnauthorizedResponseHeader(HttpActionContext actionContext)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            var parameter = string.Format("realm=\"{0}\"", host);
            return new AuthenticationHeaderValue(Scheme, parameter);
        }
    }
}