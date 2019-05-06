using System.Data.Entity;
using IT_News_DAL.Entities;

namespace IT_News_DAL.EF
{
    public  class StoreDbInitializer:DropCreateDatabaseIfModelChanges<NewsContext>
    {
        protected override void Seed(NewsContext db)
        {
            db.Sections.Add(new Section {Name = "Java"});
            db.Sections.Add(new Section { Name = "C#" });
            db.Sections.Add(new Section { Name = "Algorithms" });
            db.Sections.Add(new Section { Name = "C++" });
            db.Sections.Add(new Section { Name = "Php" });
            db.Sections.Add(new Section { Name = "Pyton" });
            db.SaveChanges();
        }
    }
}
