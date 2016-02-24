namespace Answery.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Interfaces;
    using ViewModels.Like;
    using ViewModels.User;

    public class LikesController : Controller
    {

        private readonly ILikesService likesService;
        private readonly IUsersService usersService;
        private readonly IQuestionsService questionsService;

        public LikesController(ILikesService likesService, IUsersService usersService, IQuestionsService questionsService)
        {
            this.likesService = likesService;
            this.usersService = usersService;
            this.questionsService = questionsService;
        }

        [HttpPost]
        public JsonResult Like(LikeViewModel like)
        {
            if (ModelState.IsValid)
            {
                var mapper = AutoMapperConfig.Configuration.CreateMapper();
                var likeAsModel = mapper.Map<LikeViewModel, Like>(like);
                if (likeAsModel.LikedByUserId != null)
                {
                    likeAsModel.LikedByUser = this.usersService.GetUserById(likeAsModel.LikedByUserId);
                }
                likeAsModel.Question = this.questionsService.GetById(likeAsModel.QuestionId);

                this.likesService.Add(likeAsModel);
                return Json(new { isSuccessfullyAdded = true });
            }
            return Json(new { isSuccessfullyAdded = false });
        }
    }
}