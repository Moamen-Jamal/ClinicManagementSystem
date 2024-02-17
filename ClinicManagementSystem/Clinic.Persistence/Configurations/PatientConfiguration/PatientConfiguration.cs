using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");

            builder.Property(a => a.BirthDate).HasColumnName("BirthDate").IsRequired();
            builder.Property(a => a.Gender).HasColumnName("Gender").HasMaxLength(20).IsRequired();

            builder.HasOne(i => i.User).WithMany().
                HasForeignKey(i => i.Id);

            builder.HasMany(i => i.Appointments).WithOne(i => i.Patient);
        }
    }
}
