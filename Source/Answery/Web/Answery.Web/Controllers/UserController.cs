namespace Answery.Web.Controllers
{
    using System.Web.Mvc;

    public class UserController : Controller
    {
        public ActionResult Index(string username)
        {
            return View();
        }
    }
}