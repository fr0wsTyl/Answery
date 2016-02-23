﻿namespace Answery.Web.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure.Mapping.MvcTemplate.Web.Infrastructure.Mapping;
    using Question;

    public class UserViewModel : IMapFrom<User>, IMapTo<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }
        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int AnsweredQuestions { get; set; }

        public int UnAnsweredQuestions { get; set; }

        [DataType(DataType.MultilineText)]
        public string About { get; set; }

        public IEnumerable<QuestionViewModel> Questions { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(x => x.AnsweredQuestions, opt => opt.MapFrom(x => x.Questions.Count(q => q.IsAnswered)));
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(x => x.UnAnsweredQuestions, opt => opt.MapFrom(x => x.Questions.Count(q => q.IsAnswered == false)));

        }
    }
}