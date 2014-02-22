namespace Pitchdea.Core
{
    /// <summary>
    /// Provides a simple interface for interracting with database.
    /// </summary>
    public interface ISqlTool
    {
        string InsertIdea(int userId, string title, string summary, string description);
    }
}