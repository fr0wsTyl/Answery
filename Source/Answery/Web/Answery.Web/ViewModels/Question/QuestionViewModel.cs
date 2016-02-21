namespace Answery.Web.ViewModels.Question
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Comment;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure.Mapping.MvcTemplate.Web.Infrastructure.Mapping;

    public class QuestionViewModel : IMapFrom<Question>, IMapTo<Question>
    {
        [Required]
        [MinLength(5)]
        [MaxLength(600)]
        public string Content { get; set; }

        public bool IsAnswered { get; set; }

        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual IEnumerable<CommentViewModel> Comments { get; set; }
    }
}