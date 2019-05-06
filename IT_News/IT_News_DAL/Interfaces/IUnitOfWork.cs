using System;
using IT_News_DAL.Entities;

namespace IT_News_DAL.Interfaces
{
   public  interface IUnitOfWork:IDisposable
    {
        IRepository<News> News { get; }
        void Save();
    }
}
