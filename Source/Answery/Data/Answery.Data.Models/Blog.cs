namespace Answery.Data.Models
{
    using System;
    using Common.Models;
    public class Blog : BaseModel<int>
    {
        public string Content { get; set; }

        public string Title { get; set; }
    }
}
