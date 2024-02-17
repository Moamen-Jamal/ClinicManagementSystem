using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.ToTable("Specialty");
            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

            builder.HasMany(i => i.Doctors).WithOne(i => i.Specialty);
        }
    }
}
