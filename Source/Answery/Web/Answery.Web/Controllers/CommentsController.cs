namespace Answery.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Interfaces;
    using ViewModels.Comment;
    using ViewModels.Like;

    public class CommentsController : Controller
    {

        private readonly ICommentsService commentsService;
        private readonly IUsersService usersService;
        private readonly IQuestionsService questionsService;

        public CommentsController(ICommentsService commentsService, IUsersService usersService, IQuestionsService questionsService)
        {
            this.commentsService = commentsService;
            this.usersService = usersService;
            this.questionsService = questionsService;
        }

        [HttpPost]
        public JsonResult Comment(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var mapper = AutoMapperConfig.Configuration.CreateMapper();
                var commentAsAModel = mapper.Map<CommentViewModel, Comment>(comment);
                if (commentAsAModel.AuthorId != null)
                {
                    commentAsAModel.Author = this.usersService.GetUserById(commentAsAModel.AuthorId);
                }
                commentAsAModel.Question = this.questionsService.GetById(commentAsAModel.QuestionId);

                this.commentsService.Add(commentAsAModel);
                return Json(new { isSuccessfullyAdded = true });
            }
            return Json(new { isSuccessfullyAdded = false });
        }
    }
}