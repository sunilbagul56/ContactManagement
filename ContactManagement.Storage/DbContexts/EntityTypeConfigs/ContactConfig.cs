
namespace ContactManagement.Storage.DbContexts.EntityTypeConfigs
{
    using ContactManagement.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable(nameof(Contact), "dbo");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).HasColumnName("ID");
            builder.Property(c => c.FirstName).HasColumnName("FirstName");
            builder.Property(c => c.LastName).HasColumnName("LastName");
            builder.Property(c => c.Email).HasColumnName("Email");
            builder.Property(c => c.City).HasColumnName("City");
            builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(c => c.IsActive).HasColumnName("IsActive");
        }
    }
}
