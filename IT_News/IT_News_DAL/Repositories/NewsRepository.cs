using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Create(News news)
        {
            _db.News.Add(news);
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

        public void Update(News news)
        {
            _db.Entry(news).State = EntityState.Modified;
        }
    }
}
