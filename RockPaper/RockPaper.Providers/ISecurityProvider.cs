
namespace RockPaper.Providers
{
    using System.Collections.Generic;

    /// <summary>
    /// The seucrity provider
    /// </summary>
    public interface ISecurityProvider
    {
        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Authenitcates a user
        /// </returns>
        bool AuthenticateUser(string userName, string password);

        /// <summary>
        /// Gets the user claims.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>
        /// The user claims
        /// </returns>
        IEnumerable<string> GetUserClaims(string userName);
    }
}

