namespace Answery.Web.Controllers
{
    using System.Configuration;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Interfaces;
    using ViewModels.User;

    public class UserController : Controller
    {
        private readonly IUsersService usersService;

        public UserController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public ActionResult Index(string username)
        {
            var user = this.usersService.GetUserByUsername(username);
            var userToShow = AutoMapperConfig.Configuration.CreateMapper().Map<User, UserViewModel>(user);

            return View(userToShow);
        }
    }
}