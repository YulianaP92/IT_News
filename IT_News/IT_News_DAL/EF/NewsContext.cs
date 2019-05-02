using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_News_DAL.Entities;
using System.Configuration;

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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasMany(c => c.Tags)
                .WithMany(s => s.News)
                .Map(t => t.MapLeftKey("NewsId")
                    .MapRightKey("TagsId")
                    .ToTable("NewsTags"));

            modelBuilder.Entity<Section>()
                .HasMany(p => p.News)
                .WithRequired(p => p.Section);

            modelBuilder.Entity<News>()
                .HasMany(c => c.Comments);



        }
    }
}
