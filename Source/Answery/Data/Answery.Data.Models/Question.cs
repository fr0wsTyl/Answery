namespace Answery.Data.Models
{
    using System;
    using Common.Models;
    public class Question : BaseModel<int>
    {
        public string Content { get; set; }
        public int ReceiverId { get; set; }

        public virtual User Receiver { get; set; }
    }
}
