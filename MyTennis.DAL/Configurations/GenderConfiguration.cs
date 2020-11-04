using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTennis.DAL.Entities;

namespace MyTennis.DAL.Configurations
{
    class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender");

            builder.Property(p => p.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            builder.HasIndex(p => p.Name).IsUnique();

            builder.HasData(new Gender
            {
                Id = 1,
                Name = "Man"
            });

            builder.HasData(new Gender
            {
                Id = 2,
                Name = "Vrouw"
            });
        }
    }
}
