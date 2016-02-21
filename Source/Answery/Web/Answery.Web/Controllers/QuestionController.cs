namespace Answery.Web.Controllers
{
    using System.Configuration;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Interfaces;
    using ViewModels.Question;
    using ViewModels.User;

    public class QuestionController : Controller
    {
        private readonly IQuestionsService questionsService;
        private readonly IUsersService usersService;

        public QuestionController(IQuestionsService questionsService, IUsersService usersService)
        {
            this.questionsService = questionsService;
            this.usersService = usersService;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get(string a)
        {
            return Json(new { message = "hey"}, JsonRequestBehavior.AllowGet);
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
                    return Json(new { isSuccessfulAdded = true});
                }
                return Json(new { isSuccessfulAdded = false});
            }
            else
            {
                return Json(new { isSuccessfulAdded = false});
            }
        }
    }
}