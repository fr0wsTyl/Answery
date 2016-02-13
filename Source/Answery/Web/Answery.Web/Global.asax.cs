namespace Answery.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Answery.Web.Config;
    using Data;
    using Data.Migrations;
    using Infrastructure.Mapping;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AnsweryDbContext, Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.RegisterAutofac();
            AutoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
