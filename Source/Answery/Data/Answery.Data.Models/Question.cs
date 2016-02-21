namespace Answery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    public class Question : BaseModel<int>
    {
        [Required]
        [MinLength(8)]
        [MaxLength(600)]
        public string Content { get; set; }

        public bool IsAnswered { get; set; }

        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }
    }
}
