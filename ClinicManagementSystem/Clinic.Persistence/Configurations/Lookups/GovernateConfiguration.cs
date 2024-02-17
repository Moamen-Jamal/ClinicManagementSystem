using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class GovernateConfiguration : IEntityTypeConfiguration<Governate>
    {
        public void Configure(EntityTypeBuilder<Governate> builder)
        {
            builder.ToTable("Governate");
            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.HasMany(i => i.Cities).WithOne(a => a.Governate);
        }
    }
}
