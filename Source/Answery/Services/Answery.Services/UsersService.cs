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

        private DbContext db;


        public UsersService(DbContext context)
        {
            this.Users = context.Set<User>();
            this.db = context;
        }

        public User GetUserById(string id)
        {
            return this.Users.Where(user => user.Id == id).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return this.Users.Where(user => user.UserName == username).FirstOrDefault();
        }

        public void Update(User user)
        {
            this.Users.Attach(user);
            var entry = db.Entry(user);
            entry.Property(e => e.FirstName).IsModified = true;
            entry.Property(e => e.LastName).IsModified = true;
            entry.Property(e => e.Age).IsModified = true;
            entry.Property(e => e.About).IsModified = true;
            db.SaveChanges();

        }
    }
}
