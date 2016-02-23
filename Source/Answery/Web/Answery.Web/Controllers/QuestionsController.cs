namespace Answery.Web.Controllers
{
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Interfaces;
    using ViewModels.Home;
    using ViewModels.Question;
    using ViewModels.User;

    public class QuestionsController : Controller
    {
        private readonly IQuestionsService questionsService;
        private readonly IUsersService usersService;

        public QuestionsController(IQuestionsService questionsService, IUsersService usersService)
        {
            this.questionsService = questionsService;
            this.usersService = usersService;
        }

        [Authorize]
        public ActionResult Unanswered()
        {
            var user = this.usersService.GetUserByUsername(User.Identity.Name);
            var questions = this.questionsService.GetAllUnAnsweredBy(user.Id);
            var model = new IndexViewModel()
            {
                Questions = questions.To<QuestionViewModel>().ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Asked()
        {
            var user = this.usersService.GetUserByUsername(User.Identity.Name);
            var questions = this.questionsService.GetAllAskedBy(user.Id);
            return View();
        }

        [HttpPost]
        public JsonResult Add(QuestionViewModel questionInput)
        {
            if (ModelState.IsValid)
            {
                var question =
                    AutoMapperConfig.Configuration.CreateMapper().Map<QuestionViewModel, Question>(questionInput);
                if (question.AuthorId != null)
                {
                    question.Author = this.usersService.GetUserById(question.AuthorId);
                }

                question.Receiver = this.usersService.GetUserById(question.ReceiverId);

                var questionAdded = this.questionsService.Add(question);

                //Checking if the question is added successfully
                if (questionAdded.IsAnswered == false)
                {
                    return Json(new { isSuccessfullyAdded = true });
                }
                return Json(new { isSuccessfullyAdded = false });
            }
            else
            {
                return Json(new { isSuccessfullyAdded = false });
            }
        }
    }
}