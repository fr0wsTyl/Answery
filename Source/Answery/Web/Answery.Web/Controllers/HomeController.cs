namespace Answery.Web.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Interfaces;
    using ViewModels.Question;

    public class HomeController : Controller
    {
        private readonly IQuestionsService questionsService;

        public HomeController(IQuestionsService questionsService)
        {
            this.questionsService = questionsService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var questions = questionsService.GetAllAnsweredBy(User.Identity.GetUserId());
            var model = new ViewModels.Home.IndexViewModel()
            {
                Questions = questions.To<QuestionViewModel>()
            };

            return View(model);
        }
    }
}
