using System;
using MySql.Data.MySqlClient;

namespace Pitchdea.Core.Test.Utils
{
    /// <summary>
    /// Test tool for managing the MySql test database in unit tests.
    /// </summary>
    public class SqlTestTool
    {
        /// <summary>
        /// MySql connection string used by the tool.
        /// </summary>
        public const string TestConnectionString = "SERVER=localhost; DATABASE=pitchdeatest; UID=test; PASSWORD=test;";

        private readonly MySqlConnection _connection;

        /// <summary>
        /// Constrtucs a new tool.
        /// </summary>
        public SqlTestTool()
        {
            _connection = new MySqlConnection(TestConnectionString);
        }
        
        /// <summary>
        /// Removes all users from the test database.
        /// </summary>
        public void CleanUsers()
        {
            _connection.Open();
            var query = String.Format(@"DELETE FROM user");
            var command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void CleanTestTable()
        {
            _connection.Open();
            var query = String.Format(@"DELETE FROM test");
            var command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}