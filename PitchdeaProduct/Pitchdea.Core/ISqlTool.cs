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
        /// <param name="idea">Idea to be inserted into the database.</param>
        /// <returns>The inserted idea containing the unique hash used for identification.</returns>
        Idea InsertIdea(Idea idea);
    }
}