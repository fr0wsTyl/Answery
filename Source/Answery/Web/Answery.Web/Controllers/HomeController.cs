namespace Answery.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Config;
    using Data.Common;
    using Data.Models;
    using Answery.Infrastructure.Mapping;
    using Services.Interfaces;
    using ViewModels;
    using ViewModels.Home;
    using ViewModels.Question;

    public class HomeController : Controller
    {
        private readonly IQuestionsService questionsService;

        public HomeController(IQuestionsService questionsService)
        {
            this.questionsService = questionsService;
        }

        public ActionResult Index()
        {
            var questions = questionsService.GetAll();
            var model = new ViewModels.Home.IndexViewModel()
            {
                Questions = questions.To<QuestionViewModel>()
            };

            return View(model);
        }
    }
}
