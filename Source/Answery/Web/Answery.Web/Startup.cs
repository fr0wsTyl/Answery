using Microsoft.Owin;

[assembly: OwinStartupAttribute(typeof(Answery.Web.Config.Startup))]
namespace Answery.Web.Config
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
