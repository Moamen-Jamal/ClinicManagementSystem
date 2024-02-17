using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region");
            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

            builder.Property(i => i.CityId).IsRequired();
            builder.HasOne(i => i.City).WithMany(i => i.Regions).
                HasForeignKey(i => i.CityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(i => i.Streets).WithOne(i => i.Region);
        }
    }
}
