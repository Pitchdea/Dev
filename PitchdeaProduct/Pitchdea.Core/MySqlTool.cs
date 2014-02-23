﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace Pitchdea.Core
{
    /// <summary>
    /// Sql tool using MySql.
    /// </summary>
    public class MySqlTool : ISqlTool
    {
        private readonly MySqlConnection _connection;

        /// <summary>
        /// Constructs a new tool usign the given connection string.
        /// </summary>
        /// <param name="connectionString">Connection string used for MySql connection.</param>
        public MySqlTool(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }
        
        public string InsertIdea(int userId, string title, string summary, string description)
        {
            var ideaId = SaveIdeaWithoutHash(userId, title, summary, description);
            
            //Create the unique hash by combining the idea title and unique id number.
            var shaHasher = SHA256.Create();
            var hashedBytes = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(ideaId + title));
            var hash = Convert.ToBase64String(hashedBytes).Replace("+", "");

            SaveHashWithIdea(hash, ideaId);

            return hash;
        }

        /// <summary>
        /// Inserts the idea into the database without unique hash.
        /// </summary>
        /// <returns>Inserted idea ID.</returns>
        private ulong SaveIdeaWithoutHash(int userId, string title, string summary, string description)
        {
            _connection.Open();

            var command = new MySqlCommand(
                "INSERT INTO idea (hash, title, summary, description, userId) VALUES (@hash, @title, @summary, @description, @userId); SELECT LAST_INSERT_ID();",
                _connection);
            
            command.Parameters.Add("@hash", MySqlDbType.String).Value = null;
            command.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
            command.Parameters.Add("@summary", MySqlDbType.VarChar).Value = summary;
            command.Parameters.Add("@description", MySqlDbType.MediumText).Value = description;
            command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;

            command.Prepare();
            var result = command.ExecuteScalar();

            _connection.Close();
            
            if (result == null)
            {
                throw new NotImplementedException();
            }

            return (ulong) result;
        }

        /// <summary>
        /// Saves the unique hash into the existing idea.
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="ideaId"></param>
        private void SaveHashWithIdea(string hash, ulong ideaId)
        {
            _connection.Open();
            var updateCommand = new MySqlCommand(
                "UPDATE idea SET idea.hash = @hash WHERE id = @id;",
                _connection);

            updateCommand.Parameters.Add("@hash", MySqlDbType.String).Value = hash;
            updateCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = ideaId;

            updateCommand.Prepare();
            var updateResult = updateCommand.ExecuteNonQuery();

            if (updateResult != 1)
                throw new NotImplementedException();

            _connection.Close();
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