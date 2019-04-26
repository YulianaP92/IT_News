using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT_News.Startup))]
namespace IT_News
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
