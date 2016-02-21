namespace Answery.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    public interface ICommentsService
    {
        IQueryable<Question> GetAll();

        IQueryable<Comment> GetByQuestionId(int id);

        Comment Add(Comment comment);
    }
}
