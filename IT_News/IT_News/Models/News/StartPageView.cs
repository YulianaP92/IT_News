using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_News.Models.News
{
    public class StartPageView
    {
        public  List<NewsViewModel> NewsViewModels { get; set; }
        public List<TagViewModel> TagViewModel { get; set; }
    }
}