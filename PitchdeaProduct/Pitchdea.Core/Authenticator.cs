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
        
        public UserInfo RegisterNewUser(string user, string email, string password)
        {
            //TODO: check that the email and username do not exist in the database.

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
                UserID = userId,
                Username = user
            };
        }
        
        public bool CheckIfUsernameExists(string email)
        {
            throw new NotImplementedException();
            
            //_connection.Open();
            //var query = string.Format(@"SELECT userid FROM user WHERE email = '{0}'", email);
            //var command = new MySqlCommand(query, _connection);
            //var result = command.ExecuteScalar();
            //_connection.Close();

            //return result != null;
        }

        public bool CheckIfEmailExists(string email)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Checks if the email and passsword combination is found in the database.
        /// </summary>
        /// <param name="email">Username to authenticate</param>
        /// <param name="password">Password to authenticate</param>
        /// <returns>Non-negative UserID if succesfully authenticated, otherwise "-1"</returns>
        public int Authenticate(string email, string password)
        {
            _connection.Open();
            var query = string.Format(@"SELECT salt, password, userid FROM user WHERE email = '{0}';", email);
            var command = new MySqlCommand(query, _connection);
            var reader = command.ExecuteReader();

            //The email is not found in the database.
            if (!reader.Read()) { return -1; }

            //Parse the data
            var salt = (string)reader[0];
            var dbPw = (string)reader[1];
            var userId = (int)reader[2];

            _connection.Close();

            var hash = CreateHash(password, salt);


            return SlowEquals(dbPw, hash) ? userId : -1;
        }

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