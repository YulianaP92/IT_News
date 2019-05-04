using System;

namespace IT_News_BLL.DTO
{
   public class CommentDTO
    {
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int CommentId { get; set; }
        public int AuthorDtoId { get; set; }
        public NewsDTO NewsDtoId { get; set; }
    }
}
