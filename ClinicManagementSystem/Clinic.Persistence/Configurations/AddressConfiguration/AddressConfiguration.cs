using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.Property(a => a.Description).HasColumnName("Description").HasMaxLength(500).IsRequired();

            builder.Property(i => i.ClinicId).IsRequired();
            builder.HasOne(i => i.Clinic).WithMany(i => i.Addresses).
                HasForeignKey(i => i.ClinicId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.StreetId).IsRequired();
            builder.HasOne(i => i.Street).WithMany(i => i.Addresses).
                HasForeignKey(i => i.StreetId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
