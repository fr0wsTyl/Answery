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
        private IDbRepository<Car> cars; 

        public HomeController(IDbRepository<Car> cars)
        {
            this.cars = cars;
        }

        public ActionResult Index()
        {
            var myCar = cars.All()
                .AsQueryable()
                .To<CarViewModel>()
                .FirstOrDefault();
            return View(myCar);
        }
    }
}
