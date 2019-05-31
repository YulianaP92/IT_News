using System;
using IT_News_DAL.EF;
using IT_News_DAL.Entities;
using IT_News_DAL.Interfaces;

namespace IT_News_DAL.Repositories
{
    //!!!!!!!!!!!!!!!Удалить UnitOfWork
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly NewsContext db;
        private NewsRepository newsRepository;
        private UserPageRepository userPageRepository;

        public EfUnitOfWork()
        {
            db = new NewsContext();
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

        public IRepository<UserPage> UserPage
        {
            get
            {
                if (userPageRepository == null)
                    userPageRepository = new UserPageRepository(db);
                return userPageRepository;
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
