using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using Pitchdea.Core.Model;

namespace Pitchdea.Core
{
    /// <summary>
    /// Sql tool using MySql.
    /// </summary>
    public class MySqlTool : ISqlTool
    {
        private readonly MySqlConnection _connection;

        /// <summary>
        /// Constructs a new tool using MySql with the given connection string.
        /// </summary>
        /// <param name="connectionString">Connection string used for MySql connection.</param>
        public MySqlTool(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        #region ISqlTool Members

        public string FindUsername(int userId)
        {
            _connection.Open();

            var command = new MySqlCommand(
                "SELECT username FROM user WHERE userid = @userid;",
                _connection);

            command.Parameters.Add("@userid", MySqlDbType.Int32).Value = userId;

            command.Prepare();
            var result = command.ExecuteScalar();
            
            _connection.Close();

            return (string)result;
        }

        public List<Idea> FetchAllIdeas()
        {
            _connection.Open();

            var commnad = new MySqlCommand(
                "SELECT id, hash, title, summary, description, question, imagePath, userId, likes, dislikes FROM idea",
                _connection
                );

            commnad.Prepare();

            var reader = commnad.ExecuteReader();

            var ideas = new List<Idea>();

            while (reader.Read())
            {
                var imagePath = reader["imagePath"] is DBNull ? null : (string)reader["imagePath"];
                var idea = new Idea((int)reader["userId"], (string)reader["title"], (string)reader["summary"], (string)reader["description"], (string)reader["question"])
                {
                    ImagePath = imagePath,
                    Hash = (string)reader["hash"],
                    Likes = (int)reader["likes"],
                    Dislikes = (int)reader["dislikes"],
                    Id = (int)reader["id"]
                };
                ideas.Add(idea);
            }

            _connection.Close();

            return ideas;
        }

        public int Like(int ideaId, int userId)
        {
            return InsertLike(ideaId, userId, 1);
        }
        
        public int Dislike(int ideaId, int userId)
        {
            return InsertLike(ideaId, userId, -1);
        }

        public int Unlike(int ideaId, int userId)
        {
            var likeInfo = GetLikeStatus(ideaId, userId);
            if (likeInfo == LikeStatus.Neutral)
                throw new Exception("The user doesn't have a like for this idea.");

            _connection.Open();

            var command = new MySqlCommand("DecreaseLikes", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("ideaID", MySqlDbType.Int32).Value = ideaId;
            command.Prepare();
            var result = command.ExecuteScalar();

            var command2 = new MySqlCommand(
                "DELETE FROM likes WHERE ideaId=@ideaId AND userID=@userID;",
                _connection);

            command2.Parameters.Add("@ideaId", MySqlDbType.Int32).Value = ideaId;
            command2.Parameters.Add("@userID", MySqlDbType.Int32).Value = userId;

            command2.Prepare();

            command2.ExecuteNonQuery();

            _connection.Close();

            return (int) result;
        }

        private int InsertLike(int ideaId, int userId, int likeValue)
        {
            var likeInfo = GetLikeStatus(ideaId, userId);
            if (likeInfo == LikeStatus.Like || likeInfo == LikeStatus.Dislike)
                throw new Exception("The user already likes/dislikes this idea.");
            
            _connection.Open();

            MySqlCommand command;
            if (likeValue == 1)
            {
                command = new MySqlCommand("IncrementLikes", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
            }
            else
            {
                command = new MySqlCommand("IncrementDislikes", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
            }

            command.Parameters.Add("ideaID", MySqlDbType.Int32).Value = ideaId;
            command.Prepare();
            var result = command.ExecuteScalar();

            var command2 = new MySqlCommand(
                "INSERT INTO likes (likevalue, ideaId, userId) VALUES (@likevalue, @ideaId, @userID);",
                _connection);

            command2.Parameters.Add("@likevalue", MySqlDbType.Int16).Value = likeValue;
            command2.Parameters.Add("@ideaId", MySqlDbType.Int32).Value = ideaId;
            command2.Parameters.Add("@userID", MySqlDbType.Int32).Value = userId;

            command2.Prepare();

            command2.ExecuteNonQuery();

            _connection.Close();

            return (int) result;
        }

        public LikeStatus GetLikeStatus(int ideaId, int userId)
        {
            _connection.Open();

            var command = new MySqlCommand(
                "SELECT likevalue FROM likes WHERE ideaId=@ideaID AND userId=@userID;",
                _connection);

            command.Parameters.Add("@ideaID", MySqlDbType.Int32).Value = ideaId;
            command.Parameters.Add("@userID", MySqlDbType.Int32).Value = userId;

            command.Prepare();

            var result = command.ExecuteScalar();

            _connection.Close();

            if (result == null) return LikeStatus.Neutral;
            if ((sbyte) result == 1) return LikeStatus.Like;
            if ((sbyte) result == -1) return LikeStatus.Dislike;

            throw new Exception("Like value out of range.");
        }

        #endregion


        public Idea InsertIdea(Idea idea)
        {
            var ideaId = SaveIdeaWithoutHash(idea.UserId, idea.Title, idea.Summary, idea.Description, idea.Question, idea.ImagePath);

            //Create the unique hash by combining the idea title and unique id number.
            var shaHasher = SHA256.Create();
            var hashedBytes = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(ideaId + idea.Title));
            var hash = Convert.ToBase64String(hashedBytes).Replace("+", "");

            SaveHashWithIdea(hash, ideaId);

            idea.Hash = hash;
            idea.Id = Convert.ToInt32(ideaId);

            return idea;
        }

        public Idea FetchIdea(string ideaHash)
        {
            _connection.Open();

            var command = new MySqlCommand(
                "SELECT id, hash, title, summary, description, question, imagePath, userId, likes, dislikes FROM idea WHERE hash=@hash;",
                _connection);

            command.Parameters.Add("@hash", MySqlDbType.String).Value = ideaHash;

            command.Prepare();
            var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                _connection.Close();
                return null;
            }

            var imagePath = reader["imagePath"] is DBNull ? null : (string)reader["imagePath"];

            var idea = new Idea((int)reader["userId"], (string)reader["title"], (string)reader["summary"], (string)reader["description"], (string)reader["question"])
            {
                ImagePath = imagePath,
                Hash = (string)reader["hash"],
                Likes = (int)reader["likes"],
                Dislikes = (int)reader["dislikes"],
                Id = (int)reader["id"]
            };

            if(reader.Read())
            {
                _connection.Close();
                throw new Exception("More than one idea matching the hash was found.");
            }

            _connection.Close();

            return idea;
        }
        
        /// <summary>
        /// Inserts the idea into the database without unique hash.
        /// </summary>
        /// <returns>Inserted idea ID.</returns>
        private ulong SaveIdeaWithoutHash(int userId, string title, string summary, string description, string question, string imagePath)
        {
            _connection.Open();

            var command = new MySqlCommand(
                "INSERT INTO idea (hash, title, summary, description, question, imagePath, userId) VALUES (@hash, @title, @summary, @description, @question, @imagePath, @userId); SELECT LAST_INSERT_ID();",
                _connection);
            
            command.Parameters.Add("@hash", MySqlDbType.String).Value = null;
            command.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
            command.Parameters.Add("@summary", MySqlDbType.VarChar).Value = summary;
            command.Parameters.Add("@description", MySqlDbType.Text).Value = description;
            command.Parameters.Add("@question", MySqlDbType.VarChar).Value = question;
            command.Parameters.Add("@imagePath", MySqlDbType.VarChar).Value = imagePath;
            command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;

            command.Prepare();
            var result = command.ExecuteScalar();

            _connection.Close();
            
            if (result == null)
            {
                throw new Exception("Failed to save idea.");
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
                throw new Exception("Failed to update idea.");

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
