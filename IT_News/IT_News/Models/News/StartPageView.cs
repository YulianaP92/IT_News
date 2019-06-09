using System.Collections.Generic;

namespace IT_News.Models.News
{
    public class StartPageView
    {
        public  List<NewsViewModel> NewsViewModels { get; set; }
        public List<TagViewModel> TagViewModel { get; set; }
        public List<NewsViewModel> NewsViewModelsRating { get; set; }
    }
}