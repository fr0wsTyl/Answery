namespace Answery.Web.Controllers
{
    using System.Web.Mvc;
    using ViewModels.Question;

    public class QuestionsController : Controller
    {
        [HttpPost]
        public JsonResult Add(QuestionViewModel question)
        {

            return Json();
        }
    }
}