using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_News_BLL.DTO
{
   public class SectionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<NewsDTO> News { get; set; }
    }
}
