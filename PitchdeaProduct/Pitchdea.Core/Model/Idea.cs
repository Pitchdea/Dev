namespace Pitchdea.Core.Model
{
    public class Idea
    {
        public Idea(int userId, string title, string summary, string description)
        {
            UserId = userId;
            Title = title;
            Summary = summary;
            Description = description;
        }

        public int UserId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Hash { get; set; }
    }
}