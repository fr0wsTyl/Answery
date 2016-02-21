namespace Answery.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Question;
    using User;

    public class CommentViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(300)]
        public string Content { get; set; }

        public string QuestionId { get; set; }

        public virtual QuestionViewModel Question { get; set; }

        public virtual string AuthorId { get; set; }

        public virtual UserViewModel Author { get; set; }
    }
}
