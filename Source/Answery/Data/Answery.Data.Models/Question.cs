namespace Answery.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    public class Question : BaseModel<int>
    {
        public Question()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Required]
        [MinLength(5)]
        [MaxLength(600)]
        public string Content { get; set; }

        public bool IsAnswered { get; set; }

        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        public virtual string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; } 

    }
}
