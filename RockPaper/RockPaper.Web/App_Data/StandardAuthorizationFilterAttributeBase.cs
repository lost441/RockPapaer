
namespace RockPaper.Web.App_Data
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    /// <summary>
    /// The standard authorization filter
    /// </summary>
    public abstract class StandardAuthorizationFilterAttributeBase : AuthorizationFilterAttribute
    {
        /// <summary>
        /// The _issue challenge
        /// </summary>
        private readonly bool _issueChallenge;

        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        /// </value>
        private static bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardAuthorizationFilterAttributeBase"/> class.
        /// </summary>
        /// <param name="issueChallenge">if set to <c>true</c> [issue challenge].</param>
        protected StandardAuthorizationFilterAttributeBase(bool issueChallenge)
        {
            _issueChallenge = issueChallenge;
        }

        /// <summary>
        /// Calls when a process requests authorization.
        /// </summary>
        /// <param name="actionContext">The action context, which encapsulates information for using <see cref="T:System.Web.Http.Filters.AuthorizationFilterAttribute" />.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (IsAuthenticated)
                return;

            var userName = GetAuthenticatedUser(actionContext);
            if (string.IsNullOrWhiteSpace(userName))
            {
                Challenge(actionContext);
                return;
            }
            
            var isUserAuthorized = IsUserAuthorized(userName);
            if (!isUserAuthorized)
            {
                Challenge(actionContext);
                return;
            }

            SetIdentity(actionContext, userName);
        }

        /// <summary>
        /// Sets the identity.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <param name="userName">Name of the user.</param>
        protected virtual void SetIdentity(HttpActionContext actionContext, string userName)
        {
            var identity = new GenericIdentity(userName);
            var principal = new GenericPrincipal(identity, new string[0]);

            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
                HttpContext.Current.User = principal;

            var context = actionContext.Request.GetRequestContext();
            context.Principal = principal;
        }

        /// <summary>
        /// Gets the authenticated user.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <returns></returns>
        protected abstract string GetAuthenticatedUser(HttpActionContext actionContext);

        /// <summary>
        /// Determines whether [is user authorized] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        protected abstract bool IsUserAuthorized(string userName);

        /// <summary>
        /// Gets the unauthorized response header.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <returns></returns>
        protected abstract AuthenticationHeaderValue GetUnauthorizedResponseHeader(HttpActionContext actionContext);

        /// <summary>
        /// Challenges the specified action context.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        private void Challenge(HttpActionContext actionContext)
        {
            if (!_issueChallenge)
                return;

            var headerValue = GetUnauthorizedResponseHeader(actionContext);
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Headers.WwwAuthenticate.Add(headerValue);
            actionContext.Response = response;
        }
    }
}