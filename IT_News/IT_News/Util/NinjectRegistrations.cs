using IT_News.Models;
using IT_News_BLL.DTO;
using Ninject.Modules;
using IT_News_BLL.Interfaces;
using IT_News_BLL.Services;
using IT_News_DAL.Entities;
using IT_News_DAL.Interfaces;
using IT_News_DAL.Repositories;

namespace IT_News.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IService<NewsDTO>>().To<NewsService>();
            Bind<IService<UserPageDTO>>().To<PageService>();
            Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}