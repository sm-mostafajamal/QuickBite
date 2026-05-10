using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBite.Domain.Entities;

namespace QuickBite.Infrastructure.Persistence.Configuration;


public class QuickBiteConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
               .HasColumnName("first_name");

        builder.Property(x => x.LastName)
               .HasColumnName("last_name");

        builder.Property(x => x.Email)
               .HasColumnName("email");

        builder.Property(x => x.Password)
               .HasColumnName("password");
    }
}