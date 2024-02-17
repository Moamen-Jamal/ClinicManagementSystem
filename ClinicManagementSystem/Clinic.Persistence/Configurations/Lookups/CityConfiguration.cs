using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

            builder.Property(i => i.GovernateId).IsRequired();
            builder.HasOne(i => i.Governate).WithMany(i => i.Cities).
                HasForeignKey(i => i.GovernateId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(i => i.Regions).WithOne(i => i.City);
        }
    }
}
