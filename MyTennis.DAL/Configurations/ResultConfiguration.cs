using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTennis.DAL.Entities;

namespace MyTennis.DAL.Configurations
{
    class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("Result");

            builder.Property(p => p.SetNr)
               .HasMaxLength(3)
               .IsUnicode(false)
               .IsRequired();

            builder.Property(p => p.ScoreTeamMember)
               .HasMaxLength(3)
               .IsUnicode(false);

            builder.Property(p => p.ScoreOpponent)
               .HasMaxLength(3)
               .IsUnicode(false);

            builder.HasIndex(sc => new { sc.GameId, sc.SetNr });
        }
    }
}
