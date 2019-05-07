using System;
using System.Collections.Generic;

namespace IT_News_BLL.DTO
{
   public  class NewsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ShortDescription { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public SectionDTO Section { get; set; }
        public IList<TagDTO> Tags { get; set; }
        public IList<CommentDTO> Comments { get; set; }
    }
}
