namespace Answery.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Security;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Interfaces;
    using ViewModels.Comment;
    using ViewModels.Like;
    using ViewModels.Question;
    using ViewModels.User;

    public class UserController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IQuestionsService questionsService;
        private readonly ICommentsService commentsService;
        private readonly ILikesService likesService;

        public UserController(IUsersService usersService, IQuestionsService questionsService, ILikesService likesService, ICommentsService commentsService)
        {
            this.usersService = usersService;
            this.questionsService = questionsService;
            this.commentsService = commentsService;
            this.likesService = likesService;
        }

        [Authorize]
        public int GetUnanswered()
        {
            var user = usersService.GetUserByUsername(User.Identity.Name);
            if (user != null)
            {
                var questions = this.questionsService.GetAllUnAnsweredBy(user.Id);
                return questions.Where(question => question.IsAnswered == false).Count();
            }
            return 0;
        }

        public ActionResult Index(string username)
        {
            var user = this.usersService.GetUserByUsername(username);
            var mapper = AutoMapperConfig.Configuration.CreateMapper();
            var userToShow = mapper.Map<User, UserViewModel>(user);
            if (user != null)
            {
                var questions = this.questionsService.GetAllAnsweredBy(user.Id);
                userToShow.Questions = questions.To<QuestionViewModel>().ToList();
                foreach (var question in userToShow.Questions)
                {
                    var comments = this.commentsService.GetByQuestionId(question.Id).ToList();
                    var likes = this.likesService.GetAllByQuestionId(question.Id).ToList();
                    List<CommentViewModel> commentsAsViewModels = new List<CommentViewModel>();
                    foreach (var comment in comments)
                    {

                        var commentAsViewModel = mapper.Map<Comment, CommentViewModel>(comment);
                        commentsAsViewModels.Add(commentAsViewModel);
                    }
                    question.Comments = commentsAsViewModels;

                    List<LikeViewModel> likesViewModels = new List<LikeViewModel>();
                    foreach (var like in likes)
                    {

                        var likeAsAViewModel = mapper.Map<Like, LikeViewModel>(like);
                        likesViewModels.Add(likeAsAViewModel);
                    }
                    question.Likes = likesViewModels;
                    question.Comments = commentsAsViewModels;
                }
                userToShow.Likes = this.likesService.GetAllByUser(user.Id).To<LikeViewModel>();
                return View(userToShow);
            }
            else
            {
                return View(userToShow);
            }
        }
    }
}