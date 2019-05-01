using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_News_DAL.Entities
{
   public  class News
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription{ get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn{ get; set; }

        public DateTime? Modified { get; set; }

        public Section Section { get; set; }

        public IList<Tag> Tags { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
