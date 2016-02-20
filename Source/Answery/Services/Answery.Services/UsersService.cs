namespace Answery.Services
{
    using System;
    using System.Linq;
    using Data.Common;
    using Data.Models;
    using Interfaces;
    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User> users;

        public UsersService(IDbRepository<User> users)
        {
            this.users = users;
        }

        public User GetUserById(string id)
        {
            return this.users.GetById(id);
        }

        public User GetUserByUsername(string username)
        {
            return this.users.All().Where(user => user.Username == username);
        }
    }
}
