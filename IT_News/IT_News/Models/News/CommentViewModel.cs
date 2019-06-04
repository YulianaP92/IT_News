using System;

namespace IT_News.Models.News
{
   public class CommentViewModel
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int CommentId { get; set; }
        public virtual NewsViewModel NewsViewModel { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
