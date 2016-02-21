namespace Answery.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Linq;
    using Data.Common;
    using Data.Models;
    using Interfaces;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;
        private readonly IDbRepository<Question> questions;

        public CommentsService(IDbRepository<Question> questions, IDbRepository<Comment> comments)
        {
            this.questions = questions;
            this.comments = comments;
        }

        public IQueryable<Question> GetAll()
        {
            return this.questions.All();
        }

        public IQueryable<Comment> GetByQuestionId(int id)
        {
            return this.questions.GetById(id).Comments.AsQueryable();
        }

        public Comment Add(Comment comment)
        {
            this.comments.Add(comment);
            comments.Save();
            return comment;
        }
    }
}
