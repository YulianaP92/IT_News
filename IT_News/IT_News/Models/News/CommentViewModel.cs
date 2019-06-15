using System;
using System.Collections.Generic;

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
        public int Rating { get; set; }
        public int LikeCount { get; set; }
        public virtual IList<LikePostView> PostLikes { get; set; }
    }
}
