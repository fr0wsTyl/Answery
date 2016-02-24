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

        public LikesController(ILikesService likesService)
        {
            this.likesService = likesService;
        }

        [HttpPost]
        public JsonResult Like(LikeViewModel like)
        {
            if (ModelState.IsValid)
            {
                var mapper = AutoMapperConfig.Configuration.CreateMapper();
                var likeAsModel = mapper.Map<LikeViewModel, Like>(like);
                this.likesService.Add(likeAsModel);
                return Json(new { isSuccessfullyAdded = true });
            }
            return Json(new { isSuccessfullyAdded = false });
        }
    }
}