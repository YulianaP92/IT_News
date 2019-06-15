using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_News.Models.News
{
    public class LikePostView
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int CommentId { get; set; }
        public string User { get; set; }
        public bool Like { get; set; }
    }
}