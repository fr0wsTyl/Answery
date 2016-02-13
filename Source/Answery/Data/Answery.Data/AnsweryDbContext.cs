namespace Answery.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    public class AnsweryDbContext : IdentityDbContext<User>
    {
        public AnsweryDbContext()
            : base("AnsweryDbContext", throwIfV1Schema: false)
        {
        }

        public static AnsweryDbContext Create()
        {
            return new AnsweryDbContext();
        }
    }
}
