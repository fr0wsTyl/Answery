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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}