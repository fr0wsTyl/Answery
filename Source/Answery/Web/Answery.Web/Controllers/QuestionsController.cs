namespace Answery.Web.Controllers
{
    using System.Configuration;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using ViewModels.Question;
    using ViewModels.User;

    public class QuestionsController : Controller
    {
        [HttpPost]
        public JsonResult Add(QuestionViewModel questionInput)
        {
            var question = AutoMapperConfig.Configuration.CreateMapper().Map<QuestionViewModel, Question>(questionInput);

            return System.Web.Helpers.Json();
        }
    }
}