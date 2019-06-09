using System.Collections.Generic;
using IT_News.Models.News;

namespace IT_News.Models
{
    public class UserPageViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual List<NewsViewModel> News { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        
    }
}