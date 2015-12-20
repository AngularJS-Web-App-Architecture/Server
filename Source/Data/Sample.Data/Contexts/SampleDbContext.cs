namespace Sample.Data.Contexts
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Models;
    using Contracts;
    using System.Data.Entity;
    using System;

    public class SampleDbContext : IdentityDbContext<User>, ISampleDbContext
    {
        // TODO: Rename connection string.
        public SampleDbContext()
            : base("SampleConection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<SampleModel> Samples { get; set; }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public static SampleDbContext Create()
        {
            return new SampleDbContext();
        }
    }
}