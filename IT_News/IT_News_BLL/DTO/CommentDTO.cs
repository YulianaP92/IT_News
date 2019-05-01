using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_News_BLL.DTO
{
   public class CommentDTO
    {
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int CommentId { get; set; }
        public int AuthorDtoId { get; set; }
        public int NewsDtoId { get; set; }
    }
}
