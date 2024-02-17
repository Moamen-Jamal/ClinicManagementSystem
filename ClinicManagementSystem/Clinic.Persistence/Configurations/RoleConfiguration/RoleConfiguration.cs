using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Domain.Entities;

namespace ClinicManagement.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role")
                .Property(b => b.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            builder.HasIndex(b => b.Name).IsUnique();
            builder.HasMany(b => b.UserRoles).WithOne(b => b.Role);
        }
    }
}
