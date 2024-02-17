using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(i => i.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(i => i.UserName).HasColumnName("UserName").HasMaxLength(100).IsRequired();
            builder.Property(i => i.Password).HasColumnName("Password").HasMaxLength(100).IsRequired();
            builder.Property(i => i.Phone).HasColumnName("Phone").HasMaxLength(30).IsRequired();
            builder.Property(i => i.Photo).HasColumnName("Photo").HasMaxLength(150).IsRequired();
            builder.Property(i => i.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
            builder.HasMany(i => i.UserRoles).WithOne(i => i.User);

            builder.HasIndex(i => i.UserName).IsUnique();
            builder.HasIndex(i => i.Email).IsUnique();

            builder.HasOne(i => i.Admin)
                .WithOne(i => i.User);

            builder.HasOne(i => i.Doctor)
                .WithOne(i => i.User);

            builder.HasOne(i => i.Patient)
              .WithOne(i => i.User);

            builder.HasOne(i => i.Employee)
              .WithOne(i => i.User);
        }
    }
}
