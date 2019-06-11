using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_News_BLL.DTO
{
   public  class LikePostDto
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int CommentId { get; set; }
        public string UserId { get; set; }
        public bool Like { get; set; }
    }
}
