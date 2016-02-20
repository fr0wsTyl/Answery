namespace Answery.Web.ViewModels.User
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure.Mapping.MvcTemplate.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>, IMapTo<User>, IHaveCustomMappings
    {
        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }
        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap().ForMember(x => x.)
        }
    }
}