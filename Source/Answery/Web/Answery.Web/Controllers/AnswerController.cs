﻿namespace Answery.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Interfaces;
    using ViewModels.Question;

    public class AnswerController : Controller
    {
        private readonly IAnswersService answersService;

        public AnswerController(IAnswersService answersService)
        {
            this.answersService = answersService;
        }

        [HttpPost]
        public JsonResult Add(QuestionAnswerViewModel questionInput)
        {
            if (ModelState.IsValid)
            {
                this.answersService.Add(questionInput.QuestionId, questionInput.Answer);
                return Json(new { isSuccessfulAdded = true });
            }
            else
            {
                return Json(new { isSuccessfulAdded = false });
            }
        }
}