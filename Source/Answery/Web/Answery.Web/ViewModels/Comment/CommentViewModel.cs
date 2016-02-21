namespace Answery.Web.ViewModels.Comment
{
    using System.Collections.Generic;
    using User;
    using Question;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure.Mapping.MvcTemplate.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapTo<Comment>, IMapFrom<Comment>
    {
        [Required]
        [MinLength(5)]
        [MaxLength(300)]
        public string Content { get; set; }

        public string QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
