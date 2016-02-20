namespace Answery.Web.Controllers
{
    using System.Configuration;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using ViewModels.User;

    public class UserController : Controller
    {
        public ActionResult Index(string username)
        {

            AutoMapperConfig.Configuration.CreateMapper<UserViewModel, User>();
            
            var model = new UserViewModel()
            {
                Username = username
            };
            return View(model);
        }
    }
}