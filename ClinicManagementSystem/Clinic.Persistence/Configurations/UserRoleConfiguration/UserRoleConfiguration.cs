using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");

            builder.Property(i => i.RoleId).IsRequired();
            builder.HasOne(i => i.Role).WithMany(i => i.UserRoles).
                HasForeignKey(i => i.RoleId);

            builder.Property(i => i.UserId).IsRequired();
            builder.HasOne(i => i.User).WithMany(i => i.UserRoles).
                HasForeignKey(i => i.UserId);
        }
    }
}
