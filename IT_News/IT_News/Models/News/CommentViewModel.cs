using System;

namespace IT_News.Models.News
{
   public class CommentViewModel
    {
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int CommentId { get; set; }
        public int AuthorViewModelId { get; set; }
        public NewsViewModel NewsViewModelId { get; set; }
    }
}
