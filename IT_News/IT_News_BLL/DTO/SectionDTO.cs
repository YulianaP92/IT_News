using System.Collections.Generic;

namespace IT_News_BLL.DTO
{
   public class SectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<NewsDTO> News { get; set; }
    }
}
