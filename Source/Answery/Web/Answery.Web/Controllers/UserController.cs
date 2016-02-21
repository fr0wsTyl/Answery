namespace Answery.Web.Controllers
{
    using System.Configuration;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Interfaces;
    using ViewModels.Question;
    using ViewModels.User;

    public class UserController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IQuestionsService questionsService;

        public UserController(IUsersService usersService, IQuestionsService questionsService)
        {
            this.usersService = usersService;
            this.questionsService = questionsService;
        }

        public ActionResult Index(string username)
        {
            var user = this.usersService.GetUserByUsername(username);
            var userToShow = AutoMapperConfig.Configuration.CreateMapper().Map<User, UserViewModel>(user);

            if (user != null)
            {
                var questions = this.questionsService.GetAllUnAnsweredBy(user.Id);
                userToShow.Questions = questions.To<QuestionViewModel>();
            }


            userToShow.Questions = userToShow.Questions.ToList();
            

            return View(userToShow);
        }
    }
}