using System;

namespace IT_News.Models.News
{
   public class CommentViewModel
    {
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int CommentId { get; set; }
        public virtual UserPageViewModel AuthorViewModelId { get; set; }
        public virtual NewsViewModel NewsViewModelId { get; set; }
    }
}
