namespace Answery.Web.ViewModels.Question
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Comment;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure.Mapping.MvcTemplate.Web.Infrastructure.Mapping;
    using Like;
    using User;

    public class QuestionViewModel : IMapFrom<Question>, IMapTo<Question>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(600)]
        public string Content { get; set; }
        
        [MinLength(3)]
        [MaxLength(600)]
        public string Answer { get; set; }

        public bool IsAnswered { get; set; }

        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public DateTime? AnsweredOn { get; set; }

        public IEnumerable<LikeViewModel> Likes { get; set; }

        public virtual IEnumerable<CommentViewModel> Comments { get; set; }
        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Question, QuestionViewModel>()
                .ForMember(x => x.Comments, opt => opt.Ignore());

            configuration.CreateMap<Question, QuestionViewModel>()
                .ForMember(x => x.Likes, opt => opt.Ignore());

            configuration.CreateMap<QuestionViewModel, Question>()
                .ForMember(x => x.Likes, opt => opt.Ignore());
        }
    }
}