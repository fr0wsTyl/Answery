namespace Answery.Web.ViewModels.Question
{
    using Data.Models;
    using Infrastructure.Mapping.MvcTemplate.Web.Infrastructure.Mapping;
    public class QuestionViewModel : IMapFrom<Question>
    {
        public string Content { get; set; }
    }
}