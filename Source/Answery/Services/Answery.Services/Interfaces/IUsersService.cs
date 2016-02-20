namespace Answery.Services.Interfaces
{
    using System;
    using Data.Models;

    public interface IUsersService
    {
        User GetUserById(string id);

        User GetUserByUsername(string username);
    }
}
