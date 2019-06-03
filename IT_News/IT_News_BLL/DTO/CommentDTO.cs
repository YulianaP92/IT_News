using System;

namespace IT_News_BLL.DTO
{
   public class CommentDTO
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int CommentId { get; set; }
        //public virtual UserPageDTO AuthorDto { get; set; }
        public virtual NewsDTO NewsDto { get; set; }
        public int NewsId { get; set; }
        public int AuthorId { get; set; }
    }
}
