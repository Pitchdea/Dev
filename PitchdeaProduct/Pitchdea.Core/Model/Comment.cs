using System;

namespace Pitchdea.Core.Model
{
    public class Comment
    {
        public int IdeaId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime SubmitTime { get; set; }
    }
}