using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IT_News_DAL.EF;
using IT_News_DAL.Entities;
using IT_News_DAL.Interfaces;

namespace IT_News_DAL.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        private readonly NewsContext _db;

        public NewsRepository(NewsContext context)
        {
            this._db = context;
        }
        public void Create(News news, List<Tag> tags)
        {
            Section sectionRes;
            sectionRes = _db.Sections.FirstOrDefault(x => x.Name.Equals(news.Section.Name)); //!!!!!!!!!!!!!!SectionId
            news.Section = sectionRes;
            UserPage userPage;
            userPage = _db.UserPage.FirstOrDefault(x => x.UserId.Equals(news.UserPage.UserId)); //!!!!!!!!!!!!!! UserPageId
            news.UserPage = userPage;
            // https://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework
            _db.News.Add(news);

            foreach (var tag in tags)
            {
                var allTags = _db.Tags.AsNoTracking().ToList();
                Tag tagRes;
                if (!allTags.Select(x => x.Name).Contains(tag.Name))
                {
                    tagRes = _db.Tags.Add(tag);
                }
                else
                {
                    tagRes = _db.Tags.FirstOrDefault(x => x.Name.Equals(tag.Name));
                }

                news.Tags.Add(tagRes);
            }
        }

        public void Delete(int id)
        {
            var news = _db.News.Find(id);
            if (news != null)
                _db.News.Remove(news);
        }

        public News Get(int id)
        {
            return _db.News.Find(id);
        }

        public IEnumerable<News> GetAll()
        {
            return _db.News.ToList();
        }

        public IEnumerable<Section> GetAllSections()
        {
            return _db.Sections.ToList();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _db.Tags.ToList();
        }

        public void Update(News news, List<Tag> tags)
        {
            var modifiedNewsInDb = _db.News.Find(news.Id);
            modifiedNewsInDb.Tags.Clear();
            if (modifiedNewsInDb == null) return;

            // _db.Entry(news).State = EntityState.Modified;

            List<Tag> allTags = null;
            foreach (var tag in tags)
            {
                allTags = _db.Tags.AsNoTracking().ToList();
                Tag tagRes;
                if (!allTags.Select(x => x.Name).Contains(tag.Name))
                {
                    tagRes = _db.Tags.Add(tag);
                }
                else
                {
                    tagRes = _db.Tags.FirstOrDefault(x => x.Name.Equals(tag.Name));
                }

                modifiedNewsInDb.Tags.Add(tagRes);
            }
            foreach (var tag in allTags)
            {
                if (tag.News.Count == 0)
                {
                    var tagRemove = _db.Tags.FirstOrDefault(x => x.Name.Equals(tag.Name));
                    _db.Tags.Remove(tagRemove);
                }
            }
            _db.Entry(modifiedNewsInDb).CurrentValues.SetValues(news);

            _db.Entry(modifiedNewsInDb).State = EntityState.Modified;
        }

        public void Create(Comment item)
        {
            _db.Comments.Add(item);
            _db.Entry(item).State = EntityState.Added;
        }
        public void Save(News news,decimal total)
        {
            var t= _db.News.Find(news.Id);
            if (t!=null)
            {
                t.TotalRating = total;
            }            
            _db.SaveChanges();
        }

        #region MyRegion
        public News Get(string id)
        {
            throw new System.NotImplementedException();
        }
        public void Create(News item)
        {
            throw new System.NotImplementedException();
        }
        public void Create(News item, List<News> element)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserPage> GetAllUsers()
        {
            return _db.UserPage.ToList();
        }

       

        #endregion

    }
}
