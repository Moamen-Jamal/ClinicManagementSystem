using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Domain.Entities;

namespace ClinicManagement.Persistence.Configurations
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.ToTable("Clinic");

            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(i => i.Phone).HasColumnName("Phone").HasMaxLength(30).IsRequired();

            builder.Property(i => i.DoctorId).IsRequired();
            builder.HasOne(i => i.Doctor).WithMany(i => i.Clinics).
                HasForeignKey(i => i.DoctorId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.Addresses).WithOne(i => i.Clinic);
            builder.HasMany(i => i.TimeOfClinicWorks).WithOne(i => i.Clinic);
            builder.HasMany(i => i.Appointments).WithOne(i => i.Clinic);
        }
    }
}
