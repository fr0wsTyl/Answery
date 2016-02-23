namespace Answery.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Linq;
    using Data.Common;
    using Data.Models;
    using Interfaces;

    public class QuestionsService : IQuestionsService
    {
        private readonly IDbRepository<Question> questions;

        public QuestionsService(IDbRepository<Question> questions)
        {
            this.questions = questions;
        }

        public IQueryable<Question> GetAll()
        {
            return this.questions.All();
        }

        public Question GetById(int id)
        {
            return this.questions.All().FirstOrDefault(question => question.Id == id);
        }

        public IQueryable<Question> GetAllAnsweredBy(string userId)
        {
            return this.questions.All().Where(question => question.ReceiverId == userId && question.IsAnswered);
        }

        public IQueryable<Question> GetAllUnAnsweredBy(string userId)
        {
            return this.questions.All().Where(question => question.ReceiverId == userId && question.IsAnswered == false);
        }

        public Question Add(Question question)
        {
            this.questions.Add(question);
            this.questions.Save();
            return question;
        }
    }
}
