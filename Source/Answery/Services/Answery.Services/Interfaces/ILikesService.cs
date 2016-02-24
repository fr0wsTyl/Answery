namespace Answery.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    public interface ILikesService
    {
        IQueryable<Like> GetAll();

        IQueryable<Like> GetAllByQuestionId(int id);

        IQueryable<Like> GetAllByUser(string userId);

        Like GetById(int likeId);

        void Add(Like like);

        int GetAllThatUserHas(string username);
    }
}
