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

        /// <summary>
        /// Checks if the username/email and passsword combination is found in the database.
        /// </summary>
        /// <param name="usernameOrPassword">Username or email to authenticate</param>
        /// <param name="password">Password to authenticate</param>
        /// <returns>User info for the authenticated user or null if authentication failed.</returns>
        UserInfo Authenticate(string usernameOrPassword, string password);
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
