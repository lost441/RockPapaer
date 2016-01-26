
using RockPaper.Providers;

namespace RockPaper.Web.App_Data
{
    using System;

    /// <summary>
    /// THe basic filter Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class BasicAuthorizationFilterAttribute : BasicAuthorizationFilterAttributeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthorizationFilterAttribute"/> class.
        /// </summary>
        /// <param name="issueChallenge">if set to <c>true</c> [issue challenge].</param>
        public BasicAuthorizationFilterAttribute(bool issueChallenge = true)
            : base(issueChallenge)
        {
        }

        /// <summary>
        /// Determines whether [is user authorized] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>If user is authorised</returns>
        protected override bool IsUserAuthorized(string userName)
        {
            return true;
        }

        protected override bool AuthenticateUser(string userName, string password)
        {
            var provider = ProviderFactory.GetSecurityProvider();

            var isAuthenticated = provider.AuthenticateUser(userName, password);

            if (!isAuthenticated)
            {
                return false;
            }

            return (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password));
        }
    }
}