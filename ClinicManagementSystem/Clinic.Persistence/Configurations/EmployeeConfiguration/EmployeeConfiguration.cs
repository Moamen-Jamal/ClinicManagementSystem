using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.Property(a => a.BirthDate).HasColumnName("BirthDate").IsRequired();
            builder.Property(a => a.Gender).HasColumnName("Gender").HasMaxLength(20).IsRequired();

            builder.HasOne(i => i.User).WithMany().
                HasForeignKey(i => i.Id);
        }
    }
}
