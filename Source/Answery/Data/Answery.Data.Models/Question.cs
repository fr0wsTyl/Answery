namespace Answery.Data.Models
{
    using Common.Models;
    public class Question : BaseModel<int>
    {
        public string Content { get; set; }

        public bool IsAnswered { get; set; }

        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }
    }
}
