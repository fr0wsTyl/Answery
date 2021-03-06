﻿namespace Answery.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class AnsweryDbContext : IdentityDbContext<User>
    {
        public AnsweryDbContext()
            : base("Answery", throwIfV1Schema: false)
        {
        }
        
        public static AnsweryDbContext Create()
        {
            return new AnsweryDbContext();
        }

        public virtual IDbSet<Question> Questions { get; set; } 

        public virtual IDbSet<Comment> Comments { get; set; } 

        public virtual IDbSet<Like> Likes { get; set; } 

        public virtual IDbSet<Blog> Blogs { get; set; } 

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                                                            .Where(
                                                                e =>
                                                                e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
