using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTennis.DAL.Entities;

namespace MyTennis.DAL.Configurations
{
    class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");

            builder.Property(p => p.GameNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.Date)
                .IsRequired();

            builder.HasIndex(p => p.GameNumber).IsUnique();
        }
    }
}
