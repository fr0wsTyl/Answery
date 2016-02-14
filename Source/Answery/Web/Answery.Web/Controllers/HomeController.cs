namespace Answery.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Config;
    using Data.Common;
    using Data.Models;
    using Answery.Infrastructure.Mapping;
    using ViewModels;

    public class HomeController : Controller
    {
        //private IDbRepository<Car> cars; 

        //public HomeController(IDbRepository<Car> cars)
        //{
        //    this.cars = cars;
        //}

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index()
        //{
        //    var carsToShow = cars.All()
        //        .AsQueryable();
        //    return View(carsToShow);
        //}
    }
}
