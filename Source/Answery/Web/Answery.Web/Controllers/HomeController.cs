namespace Answery.Web.Controllers
{
    using System.Web.Mvc;

    using Config;

    public class HomeController : Controller
    {
        //private IService service;

        public HomeController()
        {
            //this.service = inputService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}