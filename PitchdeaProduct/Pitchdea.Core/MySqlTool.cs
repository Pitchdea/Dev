using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Pitchdea.Core
{
    /// <summary>
    /// Sql tool using MySql.
    /// </summary>
    public class MySqlTool : ISqlTool
    {
        public string InsertIdea(int userId, string title, string summary, string description)
        {
            throw new NotImplementedException();
        }

        private readonly MySqlConnection _connection;

        /// <summary>
        /// Constructs a new tool usign the given connection string.
        /// </summary>
        /// <param name="connectionString">Connection string used for MySql connection.</param>
        public MySqlTool(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Executes a SQL statement against the connection and returns the number of rows affected.
        /// For UPDATE, INSERT, and DELETE statements, the return value is the number of rows affected by the command. For all other types of statements, the return value is -1.
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <returns>Number of rows affected</returns>
        public int ExecuteNonQuery(string query)
        {
            _connection.Open();
            var command = new MySqlCommand(query, _connection);
            var result = command.ExecuteNonQuery();
            _connection.Close();

            return result;
        }

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.
        /// </summary>
        /// <param name="query">Query to execute.</param>
        /// <returns> The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public object ReadSingleValue(string query)
        {
            _connection.Open();
            var command = new MySqlCommand(query, _connection);
            var result = command.ExecuteScalar();
            _connection.Close();

            return result;
        }

        /// <summary>
        /// Executes a query to read a data set.
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <returns>The retrieved result set.</returns>
        public object[,] ReadDataSet(string query)
        {
            _connection.Open();
            var command = new MySqlCommand(query, _connection);
            var reader = command.ExecuteReader();

            var rows = new List<object[]>();
            while (reader.Read())
            {
                var row = new object[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader[i];
                }
                rows.Add(row);
            }
            
            _connection.Close();

            if(!rows.Any())
                return new object[0,0];

            var result = new object[rows.Count,rows.First().Length];

            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    result[i, j] = rows[i][j];
                }
            }

            return result;
        }
    }
}
