using System.Collections.Generic;
using Pitchdea.Core.Model;

namespace Pitchdea.Core
{
    /// <summary>
    /// Provides a simple interface for interracting with database.
    /// </summary>
    public interface ISqlTool
    {
        /// <summary>
        /// Inserts an idea to the database and creates an unique hash for it.
        /// </summary>
        /// <param name="idea">Idea to be inserted into the database.</param>
        /// <returns>The inserted idea containing the unique hash used for identification.</returns>
        Idea InsertIdea(Idea idea);

        /// <summary>
        /// Fetches an idea with given hash from the database.
        /// </summary>
        /// <param name="ideaHash">Unique identifier hash.</param>
        /// <returns>Idea fetched from the database or null if not found.</returns>
        Idea FetchIdea(string ideaHash);

        /// <summary>
        /// Fetches the username associated with user ID.
        /// </summary>
        /// <param name="userId">The user ID to search.</param>
        /// <returns>Username associated with the user ID.</returns>
        string FindUsername(int userId);

        /// <summary>
        /// Fetches all the ideas found in the database.
        /// </summary>
        /// <returns>List of the Ideas</returns>
        List<Idea> FetchAllIdeas();

        /// <summary>
        /// Increases the like count on the idea by one and marks that the user has liked the idea.
        /// </summary>
        /// <param name="ideaId">ID of the idea</param>
        /// <param name="userId">ID of the user</param>
        /// <returns>Updated number of likes.</returns>
        int Like(int ideaId, int userId);

        /// <summary>
        /// Increases the dislike count on the idea by one and marks that the user has disliked the idea.
        /// </summary>
        /// <param name="ideaId">ID of the idea</param>
        /// <param name="userId">ID of the user</param>
        /// <returns>Updated number of dislikes.</returns>
        int Dislike(int ideaId, int userId);

        /// <summary>
        /// Decrease the like count and remove the like from this users
        /// </summary>
        /// <param name="ideaId">ID of the idea</param>
        /// <param name="userId">ID of the user</param>
        /// <returns>Updated number of likes.</returns>
        int Unlike(int ideaId, int userId);

        /// <summary>
        /// Decrease the dislike count and remove the dislike from this users
        /// </summary>
        /// <param name="ideaId">ID of the idea</param>
        /// <param name="userId">ID of the user</param>
        /// <returns>Updated number of dislikes.</returns>
        int Undislike(int ideaId, int userId);

        /// <summary>
        /// Gets the information about likes from this user on this idea.
        /// </summary>
        /// <param name="ideaId">ID of the idea</param>
        /// <param name="userId">ID of the user</param>
        /// <returns>Like info for this user and this idea.</returns>
        LikeStatus GetLikeStatus(int ideaId, int userId);

        /// <summary>
        /// Adds a comment to the idea.
        /// </summary>
        /// <param name="ideaId">ID of the idea.</param>
        /// <param name="userId">ID of the user.</param>
        /// <param name="comment">Comment text.</param>
        void InsertComment(int ideaId, int userId, string comment);

        /// <summary>
        /// Fetches all comments for this idea.
        /// </summary>
        /// <param name="ideaId"></param>
        /// <returns>List of all comments for this idea.</returns>
        List<Comment> FetchAllComments(int ideaId);
    }

    public static class SqlToolFactory
    {
        private static string _connString;

        public static string ConnectionString
        {
            get
            {
                if (_connString == null)
                {
                    var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                    _connString = config.AppSettings.Settings["MySQL.ConnectionString"].Value;
                }
                return _connString;
            }
        }

        public static ISqlTool CreateNew()
        {
            return new MySqlTool(ConnectionString);
        }
    }
}