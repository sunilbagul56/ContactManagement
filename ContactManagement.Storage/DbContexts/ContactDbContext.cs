
namespace ContactManagement.Storage.DbContexts
{
    using ContactManagement.Domain.Models;
    using ContactManagement.Storage.DbContexts.EntityTypeConfigs;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
           : base(options)
        { }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfiguration(new ContactConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
