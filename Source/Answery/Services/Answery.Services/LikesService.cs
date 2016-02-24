namespace Answery.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Linq;
    using Data.Common;
    using Data.Models;
    using Interfaces;

    public class LikesService : ILikesService
    {
        private readonly IDbRepository<Like> likes;

        public LikesService(IDbRepository<Like> likes)
        {
            this.likes = likes;
        }


        public IQueryable<Like> GetAll()
        {
            return this.likes.All();
        }

        public IQueryable<Like> GetAllByQuestionId(int id)
        {
            return this.likes.All().Where(l => l.QuestionId == id);
        }

        public IQueryable<Like> GetAllByUser(string userId)
        {
            return this.likes.All().Where(l => l.LikedByUserId == userId);
        }

        public Like GetById(int likeId)
        {
            return this.likes.All().FirstOrDefault(l => l.Id == likeId);
        }

        public void Add(Like like)
        {
            this.likes.Add(like);
            this.likes.Save();
        }

        public int GetAllThatUserHas(string username)
        {
            return this.likes.All().Where(like => like.Question.ReceiverId == username).Count();
        }
    }
}
