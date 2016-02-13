using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Answery.Web.Startup))]
namespace Answery.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
