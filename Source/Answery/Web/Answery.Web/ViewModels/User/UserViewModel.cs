namespace Answery.Web.ViewModels.User
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure.Mapping.MvcTemplate.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>, IMapTo<User>
    {
        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}