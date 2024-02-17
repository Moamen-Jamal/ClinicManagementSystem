using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");

            builder.Property(a => a.Day).HasColumnName("Day").HasMaxLength(20).IsRequired();
            builder.Property(a => a.IsComplete).HasColumnName("IsComplete").IsRequired();
            builder.Property(a => a.TimeFrom).HasColumnName("TimeFrom").IsRequired();
            builder.Property(a => a.TimeTo).HasColumnName("TimeTo").IsRequired();

            builder.Property(i => i.ClinicId).IsRequired();
            builder.HasOne(i => i.Clinic).WithMany(i => i.Appointments).
                HasForeignKey(i => i.ClinicId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.PatientId).IsRequired();
            builder.HasOne(i => i.Patient).WithMany(i => i.Appointments).
                HasForeignKey(i => i.PatientId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
