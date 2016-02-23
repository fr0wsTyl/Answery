namespace Answery.Data.Models
{
    using System;
    using Common.Models;
    public class Like : BaseModel<int>
    {
        public string LikedByUserId { get; set; }

        public User LikedByUser { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
