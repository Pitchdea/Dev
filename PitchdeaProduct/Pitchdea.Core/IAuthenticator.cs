using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitchdea.Core
{
    /// <summary>
    /// Provides methods for authentication related operations with internal database connection.
    /// </summary>
    public interface IAuthenticator
    {
        /// <summary>
        /// Registers a new user, Inserts all required information to the database. 
        /// </summary>
        /// <param name="user">Username to register</param>
        /// <param name="email">Email to register</param>
        /// <param name="password">Password to associate with the email</param>
        /// <returns>User info for the registered user or null if registration wasn't successful.</returns>
        UserInfo RegisterNewUser(string user, string email, string password);

        /// <summary>
        /// Checks if the username already exists in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if the username exists, else null.</returns>
        bool CheckIfUsernameExists(string user);

        /// <summary>
        /// Checks if the email already exists in the database
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True if the email address exists, else null.</returns>
        bool CheckIfEmailExists(string email);
    }
    public class UserInfo
    {
        public int UserID { get; set; }
        public string Username { get; set; }
    }

    public static class AuthenticatorFactory
    {
        public static IAuthenticator CreateNew()
        {
            return new Authenticator(SqlToolFactory.ConnectionString);
        }
    }


}
