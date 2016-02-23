namespace Answery.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    public interface IQuestionsService
    {
        IQueryable<Question> GetAll();

        Question GetById(int id);

        IQueryable<Question> GetAllAnsweredBy(string userId);

        IQueryable<Question> GetAllUnAnsweredBy(string userId);

        IQueryable<Question> GetAllAskedBy(string userId);

        Question Add(Question question);
    }
}
