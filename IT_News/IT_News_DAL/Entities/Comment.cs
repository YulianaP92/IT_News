using System;

namespace IT_News_DAL.Entities
{
    public class Comment
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int CommentId { get; set; }
        public virtual int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public virtual News News { get; set; }
    }
}
