using System;
using MySql.Data.MySqlClient;

namespace Pitchdea.Specs.Selenium.Utils
{
    public class SqlTestTool
    {
        public const string ConnectionString = "SERVER=localhost; DATABASE=pitchdeatest; UID=test; PASSWORD=test;";

        private readonly MySqlConnection _connection;

        public SqlTestTool()
        {
            _connection = new MySqlConnection(ConnectionString);
        }

        public void CleanUsers()
        {
            _connection.Open();
            var query = String.Format(@"DELETE FROM user");
            var command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}