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

        public string GetByQuestionId(int questionId)
        {
            return this.questions.GetById(questionId).Answer;
        }

        public void Add(int questionId, string answer)
        {
            this.questions.GetById(questionId).Answer = answer;
            this.questions.Save();
        }
    }
}
