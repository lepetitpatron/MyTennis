using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTennis.DAL.Entities;

namespace MyTennis.DAL.Configurations
{
    class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.ToTable("League");

            builder.Property(p => p.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.HasIndex(p => p.Name).IsUnique();

            builder.HasData(new League { Id = 1, Name = "Recreatief" });
            builder.HasData(new League { Id = 2, Name = "Competitie" });
            builder.HasData(new League { Id = 3, Name = "Toptennis" });
        }
    }
}
