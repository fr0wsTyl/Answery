namespace Answery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    public class Comment : BaseModel<int>
    {
        [Required]
        [MinLength(5)]
        [MaxLength(300)]
        public string Content { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
