using System.Collections.Generic;

namespace IT_News_DAL.Entities
{
   public  class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IList<News> News { get; set; }
    }
}
