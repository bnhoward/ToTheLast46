using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToTheLast46.Web.Startup))]
namespace ToTheLast46.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
