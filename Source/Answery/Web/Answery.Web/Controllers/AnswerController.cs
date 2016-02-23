namespace Answery.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Interfaces;

    public class AnswerController : Controller
    {
        private readonly IAnswersService answersService;

        public AnswerController(IAnswersService answersService)
        {
            this.answersService = answersService;
        }

        [HttpPost]
        public JsonResult Add(QuestionAnswerViewModel questionInput)
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
                    return Json(new { isSuccessfulAdded = true });
                }
                return Json(new { isSuccessfulAdded = false });
            }
            else
            {
                return Json(new { isSuccessfulAdded = false });
            }
        }
}