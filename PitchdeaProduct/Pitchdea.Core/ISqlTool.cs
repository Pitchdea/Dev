namespace Pitchdea.Core
{
    /// <summary>
    /// Provides a simple interface for interracting with database.
    /// </summary>
    public interface ISqlTool
    {
        /// <summary>
        /// Inserts an idea to the database.
        /// </summary>
        /// <param name="userId">ID of the idea's owner.</param>
        /// <param name="title">Idea title.</param>
        /// <param name="summary">Idea summary.</param>
        /// <param name="description">Idea description</param>
        /// <returns>Unique hash used to identifying the idea.</returns>
        string InsertIdea(int userId, string title, string summary, string description);
    }
}