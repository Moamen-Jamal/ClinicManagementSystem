using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class StreetConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.ToTable("Street");
            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

            builder.Property(i => i.RegionId).IsRequired();
            builder.HasOne(i => i.Region).WithMany(i => i.Streets).
                HasForeignKey(i => i.RegionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(i => i.Addresses).WithOne(i => i.Street);
        }
    }
}
