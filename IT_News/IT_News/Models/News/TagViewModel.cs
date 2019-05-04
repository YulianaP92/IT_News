using System.Collections.Generic;

namespace IT_News.Models.News
{
    public  class TagViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<NewsViewModel> News { get; set; }
    }
}
