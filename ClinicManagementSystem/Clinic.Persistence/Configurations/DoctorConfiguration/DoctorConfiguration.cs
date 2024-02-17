using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");

            builder.Property(a => a.Age).HasColumnName("Age").HasMaxLength(3).IsRequired();
            builder.Property(a => a.Fees).HasColumnName("Fees").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(a => a.Education).HasColumnName("Education").HasMaxLength(300).IsRequired();
            builder.Property(a => a.TotalRate).HasColumnName("TotalRate").IsRequired();

            builder.Property(i => i.SpecialtyId).IsRequired();
            builder.HasOne(i => i.Specialty).WithMany(i => i.Doctors).
                HasForeignKey(i => i.SpecialtyId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.Clinics).WithOne(i => i.Doctor);
            builder.HasMany(i => i.Reviews).WithOne(i => i.Doctor);

            builder.HasOne(i => i.User).WithMany().
                HasForeignKey(i => i.Id);
        }
    }
}
