namespace Answery.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    public interface IAnswersService
    {
        string GetByQuestionId(int questionId);

        void Add(int questionId, string answer);
    }
}
