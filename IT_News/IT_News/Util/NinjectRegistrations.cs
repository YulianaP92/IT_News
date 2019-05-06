using Ninject.Modules;
using IT_News_BLL.Interfaces;
using IT_News_BLL.Services;
using IT_News_DAL.Interfaces;
using IT_News_DAL.Repositories;

namespace IT_News.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<INewsService>().To<NewsService>();
            Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}