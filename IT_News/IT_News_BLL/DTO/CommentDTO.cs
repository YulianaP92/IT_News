using System;
using System.Collections.Generic;

namespace IT_News_BLL.DTO
{
   public class CommentDTO
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int CommentId { get; set; }
        public virtual NewsDTO NewsDto { get; set; }
        public int NewsId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int Rating { get; set; }
        public int LikeCount { get; set; }
        public virtual IList<LikePostDto> PostLikes { get; set; }
}
}
