using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
    }

    public static class SqlToolFactory
    {
        private static string _connString = null;

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