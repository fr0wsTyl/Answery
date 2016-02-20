namespace Answery.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using Question;

    public class IndexViewModel
    {
        public IEnumerable<QuestionViewModel> Questions { get; set; } 
    }
}