using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");

            builder.Property(a => a.Rate).HasColumnName("Rate").IsRequired();
            builder.Property(a => a.Comment).HasColumnName("Comment").HasMaxLength(500).IsRequired();

            builder.Property(i => i.DoctorId).IsRequired();
            builder.HasOne(i => i.Doctor).WithMany(i => i.Reviews).
                HasForeignKey(i => i.DoctorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
