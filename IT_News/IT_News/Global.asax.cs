using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IT_News.Models;
using IT_News.Util;
using IT_News_DAL.EF;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace IT_News
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());
            Database.SetInitializer<NewsContext>(new StoreDbInitializer());
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();

            NinjectModule newsModule = new NinjectRegistrations();
            var kernel = new StandardKernel(newsModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];
            if (cookie != null && cookie.Value != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
                System.Threading.Thread.CurrentThread.CurrentUICulture=new System.Globalization.CultureInfo(cookie.Value);
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("EN");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("EN");
            }
        }
    }
}
