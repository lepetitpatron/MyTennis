using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTennis.DAL.Entities;

namespace MyTennis.DAL.Configurations
{
    class FineConfiguration : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            builder.ToTable("Fine");

            builder.Property(p => p.FineNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.Amount)
                .HasColumnType("decimal(7,2)")
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.HandoutDate)
                .IsRequired();

            builder.HasIndex(p => p.FineNumber).IsUnique();
        }
    }
}
