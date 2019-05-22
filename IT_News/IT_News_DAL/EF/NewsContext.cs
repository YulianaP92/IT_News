using System.Data.Entity;
using IT_News_DAL.Entities;

namespace IT_News_DAL.EF
{
    public class NewsContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserPage> UserPage { get; set; }
        public NewsContext() : base("NewsContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .HasMany<Tag>(c => c.Tags)
                .WithMany(s => s.News);


            modelBuilder.Entity<Section>()
                .HasMany(p => p.News)
                .WithRequired(p => p.Section);

            modelBuilder.Entity<News>()
                .HasMany(c => c.Comments)
                .WithRequired(p => p.News);

            modelBuilder.Entity<UserPage>()
                .HasMany(c => c.News)
                .WithRequired(p => p.UserPage);

            //modelBuilder.Entity<Arbitter>()
            //    .HasRequired(a => a.Game)
            //    .WithRequiredPrincipal(g => g.Arbitter);
        }
    }
}
