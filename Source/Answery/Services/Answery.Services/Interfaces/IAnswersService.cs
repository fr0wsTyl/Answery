namespace Answery.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    public interface IAnswersService
    {
        IQueryable<Question> GetByQuestionId(int questionId);

        void Add(int questionId, string answer);
    }
}
