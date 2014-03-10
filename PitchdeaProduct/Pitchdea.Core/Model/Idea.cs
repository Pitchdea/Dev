namespace Pitchdea.Core.Model
{
    public class Idea
    {
        public Idea(int userId, string title, string summary, string description, string question)
        {
            UserId = userId;
            Title = title;
            Summary = summary;
            Description = description;
            Question = question;
        }

        public int UserId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Question { get; set; }
        public string Hash { get; set; }
        public string ImagePath { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Id { get; set; }
    }
}