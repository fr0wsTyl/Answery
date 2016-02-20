namespace Answery.Web.Controllers
{
    using System.Web.Mvc;
    using ViewModels.User;

    public class UserController : Controller
    {
        public ActionResult Index(string username)
        {
            var model = new UserViewModel()
            {
                Username = username
            };
            return View(model);
        }
    }
}