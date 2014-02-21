using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace Pitchdea.Core
{
    /// <summary>
    /// Provides methods for authentication related operations with internal database connection.
    /// </summary>
    public class Authenticator
    {
        private readonly MySqlConnection _connection;

        ///// <summary>
        ///// Construct a new authenticator using default configuration.
        ///// </summary>
        //public Authenticator()
        //{
        //    const string server = "localhost";
        //    const string database = "pitchdea";
        //    const string uid = "root";
        //    const string pw = "root";
        //    var connectionString = string.Format("SERVER={0}; DATABASE={1}; UID={2}; PASSWORD={3};", server, database, uid, pw);
        //    _connection = new MySqlConnection(connectionString);
        //}

        /// <summary>
        /// Construct a new authenticator using default configuration.
        /// </summary>
        public Authenticator(string connectionstring)
        {
            _connection = new MySqlConnection(connectionstring);
        }

        /// <summary>
        /// Authenticates the user. Return true if succesfully authenticated.
        /// </summary>
        /// <param name="email">Username to authenticate</param>
        /// <param name="password">Password to authenticate</param>
        /// <returns>True if succesfully authenticated</returns>
        public string Authenticate(string email, string password)
        {
            _connection.Open();
            var query = string.Format(@"SELECT salt, password, userid FROM user WHERE email = '{0}';", email);
            var command = new MySqlCommand(query, _connection);
            var reader = command.ExecuteReader();

            if (!reader.Read()) { return "-1"; }

            var salt = (string)reader[0];
            var dbPw = (string)reader[1];
            var userId = reader[2].ToString();

            _connection.Close();

            var hash = CreateHash(password, salt);
            //var dbPw = (string)result;
            //TODO: constant time equals
            return dbPw == hash ? userId : "-1";
        }

        /// <summary>
        /// Checks if the email already exists in the database.
        /// </summary>
        /// <param name="email">Username to check</param>
        /// <returns>True if user already exists</returns>
        public bool CheckIfUsernameExists(string email)
        {
            _connection.Open();
            var query = string.Format(@"SELECT userid FROM user WHERE email = '{0}'", email);
            var command = new MySqlCommand(query, _connection);
            var result = command.ExecuteScalar();
            _connection.Close();

            return result != null;
        }

        /// <summary>
        /// Registers the new user. Inserts all required information to the database.
        /// </summary>
        /// <param name="email">Username to register</param>
        /// <param name="password">Password to associate with the email</param>
        public void RegisterNewUser(string email, string password)
        {
            var salt = GenerateNewSalt();
            var passwordHash = CreateHash(password, salt);
            var saltString = Convert.ToBase64String(salt);

            _connection.Open();
            var query = string.Format(@"INSERT INTO user (email, salt, password) VALUES('{0}', '{1}', '{2}');", 
                email,
                saltString,
                passwordHash
                );
            var command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

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

        private string CreateHash(string password, string salt)
        {
            return CreateHash(password, Convert.FromBase64String(salt));
        }

        private static byte[] GenerateNewSalt()
        {
            var gen = RandomNumberGenerator.Create();
            var bytes = new byte[32];
            gen.GetNonZeroBytes(bytes);
            return bytes;
        }
    }
}