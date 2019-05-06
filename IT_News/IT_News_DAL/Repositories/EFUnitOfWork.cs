using System;
using IT_News_DAL.EF;
using IT_News_DAL.Entities;
using IT_News_DAL.Interfaces;

namespace IT_News_DAL.Repositories
{
    public class IUnitOfWork : Interfaces.IUnitOfWork
    {
        private readonly NewsContext db;
        private NewsRepository newsRepository;

        public IUnitOfWork(string connectionString)
        {
            db = new NewsContext(connectionString);
        }
        public IRepository<News> News
        {
            get
            {
                if (newsRepository == null)
                    newsRepository = new NewsRepository(db);
                return newsRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
