using System.Collections.Generic;

namespace IT_News.Models.News
{
    public class SectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<NewsViewModel> News { get; set; }
    }
}
