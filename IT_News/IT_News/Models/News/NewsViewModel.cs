using System;
using System.Collections.Generic;

namespace IT_News.Models.News
{
    public  class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public SectionViewModel Section { get; set; }
        public IList<TagViewModel> Tags { get; set; }
        public IList<CommentViewModel> Comments { get; set; }
    }
}
