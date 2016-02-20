namespace Answery.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Data.Common;
    using Data.Models;
    using Interfaces;

    public class UsersService : IUsersService
    {
        private IDbSet<User> Users { get; }

        public UsersService(DbContext context)
        {
            this.Users = context.Set<User>();
        }

        public User GetUserById(string id)
        {
            return this.Users.Where(user => user.Id == id).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return this.Users.Where(user => user.UserName == username).FirstOrDefault();
        }
    }
}
