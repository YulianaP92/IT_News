using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_News_DAL.Entities
{
   public  class NewsDal
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription{ get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn{ get; set; }

        public DateTime? Modified { get; set; }

        public SectionDal Section { get; set; }

        public IList<TagDal> Tags { get; set; }

        public IList<CommentDal> Comments { get; set; }
    }
}
