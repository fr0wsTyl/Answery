namespace Answery.Web.ViewModels.Question
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping.MvcTemplate.Web.Infrastructure.Mapping;
    public class QuestionViewModel : IMapFrom<Question>
    {
        [Required]
        [MinLength(5)]
        [MaxLength(600)]
        public string Content { get; set; }
    }
}