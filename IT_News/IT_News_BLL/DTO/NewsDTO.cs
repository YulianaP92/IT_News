using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_News_BLL.DTO
{
   public  class NewsDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public SectionDTO Section { get; set; }

        public IList<TagDTO> Tags { get; set; }

        public IList<CommentDTO> Comments { get; set; }
    }
}
