namespace Answery.Web.ViewModels.Like
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure.Mapping.MvcTemplate.Web.Infrastructure.Mapping;
    using Question;
    using User;

    public class LikeViewModel : IMapFrom<Like>, IMapTo<Like>
    {
        public int Id { get; set; }

        public bool IsLiked { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LikedByUserId { get; set; }

        public int QuestionId { get; set; }
        
    }
}
