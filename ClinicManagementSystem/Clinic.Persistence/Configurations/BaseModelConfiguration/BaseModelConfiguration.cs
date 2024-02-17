using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Domain.Entities;

namespace ClinicManagement.Persistence.Configurations
{
    public class BaseModelConfiguration : IEntityTypeConfiguration<BaseModel>
    {
        public void Configure(EntityTypeBuilder<BaseModel> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
            .ValueGeneratedOnAdd();

            builder.Property(i => i.CreatedDate).IsRequired();
            builder.Property(i => i.ModifiedDate).HasDefaultValue(new DateTime()).IsRequired();
        }

    }
}
