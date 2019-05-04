using System.Collections.Generic;

namespace IT_News_DAL.Entities
{
   public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<News> News { get; set; }
    }
}
