namespace Answery.Web.Controllers
{
    using System.Configuration;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Interfaces;
    using ViewModels.Question;
    using ViewModels.User;

    public class QuestionsController : Controller
    {
        private readonly IQuestionsService questionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            this.questionsService = questionsService;
        }

        [HttpGet]
        public JsonResult Get()
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
                var questionAdded = this.questionsService.Add(question);
                return Json(questionAdded);
            }
            else
            {
                return Json(new { message = "Invalid data"});
            }
        }
    }
}