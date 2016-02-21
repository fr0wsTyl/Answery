namespace Answery.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Interfaces;
    using ViewModels.Comment;
    using ViewModels.Question;
    using ViewModels.User;

    public class UserController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IQuestionsService questionsService;
        private readonly ICommentsService commentsService;

        public UserController(IUsersService usersService, IQuestionsService questionsService, ICommentsService commentsService)
        {
            this.usersService = usersService;
            this.questionsService = questionsService;
            this.commentsService = commentsService;
        }

        public ActionResult Index(string username)
        {

           

            var user = this.usersService.GetUserByUsername(username);
            var mapper = AutoMapperConfig.Configuration.CreateMapper();
            var userToShow = mapper.Map<User, UserViewModel>(user);
            this.commentsService.Add(new Comment
            {
                Author = user,
                QuestionId = "5",
            });
            if (user != null)
            {
                
                var questions = this.questionsService.GetAllUnAnsweredBy(user.Id);
                userToShow.Questions = questions.To<QuestionViewModel>().ToList();
                foreach (var question in userToShow.Questions)
                {
                    var comments = this.commentsService.GetByQuestionId(question.Id);
                    List<CommentViewModel> commentsAsViewModels = new List<CommentViewModel>();
                    foreach (var comment in comments)
                    {
                        var commentAsViewModel = mapper.Map<Comment, CommentViewModel>(comment);
                        commentsAsViewModels.Add(commentAsViewModel);
                    }
                    question.Comments = commentsAsViewModels;
                }

            }

            return View(userToShow);
        }
    }
}