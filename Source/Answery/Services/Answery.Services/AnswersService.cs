namespace Answery.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Linq;
    using Data.Common;
    using Data.Models;
    using Interfaces;

    public class AnswersService : IAnswersService
    {
        private readonly IDbRepository<Question> questions;

        public AnswersService(IDbRepository<Question> questions)
        {
            this.questions = questions;
        }

        public IQueryable<Question> GetByQuestionId(int questionId)
        {
            throw new NotImplementedException();
        }

        public void Add(int questionId, string answer)
        {
            throw new NotImplementedException();
        }
    }
}
