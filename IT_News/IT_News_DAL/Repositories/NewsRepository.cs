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
            // https://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework
            _db.News.Add(news);

            foreach (var tag in tags)
            {
                var allTags = _db.Tags.ToList();
                Tag tagRes;
                if (!allTags.Select(x=>x.Name).Contains(tag.Name))
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
            return _db.News;
        }

        public IEnumerable<Section> GetAllSections()
        {
            return _db.Sections;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _db.Tags;
        }

        //public IEnumerable<TagClouds> GetTagClouds()
        //{
        //    var totalNews = _db.News.Count();
        //    var tags = _db.Tags.ToList();
        //    return (from c in tags
        //            orderby c.Name
        //        select new TagClouds
        //        {
        //            Id = c.Id,
        //            Name = c.Name,
        //            CountOfTag = c.News.Count,
        //            TotalNews = totalNews,
        //        });
        //}

        public void Update(News news)
        {
            _db.Entry(news).State = EntityState.Modified;
        }
    }
}
