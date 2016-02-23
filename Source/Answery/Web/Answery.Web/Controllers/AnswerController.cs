namespace Answery.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Interfaces;
    using ViewModels.Question;

    public class AnswersController : Controller
    {
        private readonly IAnswersService answersService;

        public AnswersController(IAnswersService answersService)
        {
            this.answersService = answersService;
        }

        [HttpPost]
        public JsonResult Add(QuestionAnswerViewModel questionInput)
        {
            if (ModelState.IsValid)
            {
                this.answersService.Add(questionInput.QuestionId, questionInput.Answer);
                return Json(new { isSuccessfullyAdded = true });
            }
            return Json(new { isSuccessfullyAdded = false });
        }
    }
}