using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_News_DAL.Entities;

namespace IT_News_DAL.EF
{
   public  class NewsContext:DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Tag> Tags { get; set; }

        //public NewsContext()
        //{
        //    Database.SetInitializer<NewsContext>(new StoreDbInitializer());
        //}

        public NewsContext(string connectionString) : base(connectionString)
        {
                
        }
    }
}
