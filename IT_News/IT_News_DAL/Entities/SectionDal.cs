using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_News_DAL.Entities
{
   public class SectionDal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<NewsDal> News { get; set; }
    }
}
