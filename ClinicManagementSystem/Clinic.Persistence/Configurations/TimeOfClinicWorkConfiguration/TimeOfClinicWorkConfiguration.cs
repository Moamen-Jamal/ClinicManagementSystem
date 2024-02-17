using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Domain.Entities;

namespace ClinicManagement.Persistence.Configurations
{
    public class TimeOfClinicWorkConfiguration : IEntityTypeConfiguration<TimeOfClinicWork>
    {
        public void Configure(EntityTypeBuilder<TimeOfClinicWork> builder)
        {
            builder.ToTable("TimeOfClinicWork");

            builder.Property(a => a.Day).HasColumnName("Day").HasMaxLength(20).IsRequired();
            builder.Property(a => a.TimeFrom).HasColumnName("TimeFrom").IsRequired();
            builder.Property(a => a.TimeTo).HasColumnName("TimeTo").IsRequired();

            builder.Property(i => i.ClinicId).IsRequired();
            builder.HasOne(i => i.Clinic).WithMany(i => i.TimeOfClinicWorks).
                HasForeignKey(i => i.ClinicId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
