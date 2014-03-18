using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace Pitchdea.Core
{
    /// <summary>
    /// Provides methods for authentication related operations with internal database connection.
    /// </summary>
    public class Authenticator : IAuthenticator
    {
        private readonly MySqlConnection _connection;

        /// <summary>
        /// Construct a new authenticator using the given connection string for database connection.
        /// </summary>
        public Authenticator(string connectionstring)
        {
            _connection = new MySqlConnection(connectionstring);
        }

        #region IAuthenticator Members
        
        public bool CheckIfUsernameExists(string username)
        {
            _connection.Open();

            var command = new MySqlCommand(
                "SELECT count(*) FROM user WHERE username = @username;",
                _connection);

            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;

            command.Prepare();
            var count = Convert.ToInt64(command.ExecuteScalar());

            _connection.Close();

            if (count == 1) return true;
            if (count == 0) return false;
            
            //count > 1 or count < 0
            throw new Exception("Duplicate username in the database: " + username);
        }

        public bool CheckIfEmailExists(string email)
        {
            _connection.Open();

            var command = new MySqlCommand(
                "SELECT count(*) FROM user WHERE email = @email;",
                _connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

            command.Prepare();
            var count = Convert.ToInt64(command.ExecuteScalar());

            _connection.Close();

            if (count == 1) return true;
            if (count == 0) return false;

            //count > 1 or count < 0
            throw new Exception("Duplicate email in the database: " + email);
        }

        public UserInfo RegisterNewUser(string user, string email, string password)
        {
            if (CheckIfUsernameExists(user))
                throw new Exception("Username \"" + user + "\" already exists." );

            if (CheckIfEmailExists(email))
                throw new Exception("Email \"" + email + "\" already exists.");

            var salt = GenerateNewSalt();
            var passwordHash = CreateHash(password, salt);
            var saltString = Convert.ToBase64String(salt);

            _connection.Open();
            var command = new MySqlCommand(
                "INSERT INTO user (username, email, salt, password) VALUES(@username, @email, @salt, @password); SELECT LAST_INSERT_ID();",
                _connection);

            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = user;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@salt", MySqlDbType.String).Value = saltString;
            command.Parameters.Add("@password", MySqlDbType.String).Value = passwordHash;
            
            command.Prepare();

            var result = command.ExecuteScalar();

            _connection.Close();

            var userId = Convert.ToInt32((ulong) result);

            return new UserInfo
            {
                UserId = userId,
                Username = user
            };
        }

        public UserInfo Authenticate(string usernameOrPassword, string password)
        {
            _connection.Open();
            var command = new MySqlCommand(
                "SELECT salt, password, userid, username FROM user WHERE email = @email OR username = @username;",
                _connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = usernameOrPassword;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = usernameOrPassword;

            command.Prepare();

            var reader = command.ExecuteReader();

            //The email is not found in the database.
            if (!reader.Read()){ return null; }

            //Parse the data
            var salt = (string)reader["salt"];
            var dbPw = (string)reader["password"];
            var userId = (int)reader["userId"];
            var username = (string)reader["username"];

            _connection.Close();

            var hash = CreateHash(password, salt);
            
            var areEqual = SlowEquals(dbPw, hash);

            if (areEqual)
            {
                return new UserInfo
                {
                    UserId = userId,
                    Username = username
                };
            }

            return null;
        }

        public bool ValidateBetaKey(string email, string betakey)
        {
            _connection.Open();

            var command = new MySqlCommand(
                "SELECT count(*) FROM betakeys WHERE email = @email AND betakey=@betakey;",
                _connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@betakey", MySqlDbType.String).Value = betakey;

            command.Prepare();
            var count = Convert.ToInt64(command.ExecuteScalar());

            _connection.Close();

            if (count == 1) return true;
            if (count == 0) return false;

            return false;
        }

        #endregion
        
        /// <summary>
        /// Creates SHA256 hash from password and SALT.
        /// </summary>
        /// <param name="password">Password to be hashed.</param>
        /// <param name="salt">SALT to be hashed in string format.</param>
        /// <returns>The hash in Base64String format.</returns>
        private string CreateHash(string password, string salt)
        {
            return CreateHash(password, Convert.FromBase64String(salt));
        }

        /// <summary>
        /// Creates SHA256 hash from password and SALT.
        /// </summary>
        /// <param name="password">Password to be hashed.</param>
        /// <param name="salt">SALT to be hashed in byte array format.</param>
        /// <returns>The hash in Base64String format.</returns>
        private string CreateHash(string password, byte[] salt)
        {
            var shaHasher = SHA256.Create();
            var inputBytes = Encoding.UTF8.GetBytes(password);

            // Combine salt and input bytes
            var saltedInput = new Byte[salt.Length + inputBytes.Length];
            salt.CopyTo(saltedInput, 0);
            inputBytes.CopyTo(saltedInput, salt.Length);

            var hashedBytes = shaHasher.ComputeHash(saltedInput);
            
            return Convert.ToBase64String(hashedBytes);
        }

        /// <summary>
        /// Generates a new SALT for the user.
        /// </summary>
        /// <returns>The newly generated SALT</returns>
        private static byte[] GenerateNewSalt()
        {
            var gen = RandomNumberGenerator.Create();
            var bytes = new byte[32];
            gen.GetNonZeroBytes(bytes);
            return bytes;
        }

        /// <summary>
        /// Performs and length-constant equals operation to two strings.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True, if a and b are equal, otherwise false</returns>
        private static bool SlowEquals(string a, string b)
        {
            return SlowEquals(Convert.FromBase64String(a), Convert.FromBase64String(b));
        }


        //Source: https://crackstation.net/hashing-security.htm - How does the SlowEquals code work?
        /// <summary>
        /// Performs and length-constant equals operation to two byte arrays.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True, if a and b are equal, otherwise false</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            int diff = a.Length ^ b.Length;
            for(int i = 0; i < a.Length && i < b.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}