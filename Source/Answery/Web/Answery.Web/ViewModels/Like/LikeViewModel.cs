namespace Answery.Web.ViewModels.Like
{
    using System;
    using Question;
    using User;

    public class LikeViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string LikedByUserId { get; set; }

        public UserViewModel LikedByUser { get; set; }

        public int QuestionId { get; set; }

        public virtual QuestionViewModel Question { get; set; }
    }
}
