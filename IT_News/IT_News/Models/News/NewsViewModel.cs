using System;
using System.Collections.Generic;
using IT_News_BLL.DTO;

namespace IT_News.Models.News
{
    public  class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public bool Published { get; set; }
        public DateTime? PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public virtual SectionViewModel Section { get; set; }
        public int SectionId { get; set; }
        public virtual IList<TagViewModel> Tags { get; set; }
        public virtual IList<CommentViewModel> Comments { get; set; }
        public virtual UserPageViewModel UserPage { get; set; }
        public decimal TotalRating { get; set; }
    }
}
