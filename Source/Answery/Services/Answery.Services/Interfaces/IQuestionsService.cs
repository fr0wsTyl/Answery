namespace Answery.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    public interface IQuestionsService
    {
        IQueryable<Question> GetAll();

        Question GetById(int id);

    }
}
