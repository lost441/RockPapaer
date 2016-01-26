
namespace RockPaper.Providers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The security adapter
    /// </summary>
    public class SecurityProvider : ISecurityProvider
    {
        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>If the user is authenticated</returns>
        public bool AuthenticateUser(string userName, string password)
        {
            var userIsMatch = string.Equals(Properties.Settings.Default.Username, userName,
                StringComparison.CurrentCultureIgnoreCase);

            var passwordIsMatch = string.Equals(Properties.Settings.Default.Password, password,
                StringComparison.CurrentCultureIgnoreCase);

            return (userIsMatch && passwordIsMatch);
        }

        /// <summary>
        /// Gets the user claims.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The user claims</returns>
        public IEnumerable<string> GetUserClaims(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
