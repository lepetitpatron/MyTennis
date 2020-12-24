using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTennis.DAL.Entities;

namespace MyTennis.DAL.Configurations
{
    class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member");

            builder.Property(p => p.FederationNr)
               .HasMaxLength(10)
               .IsUnicode(false)
               .IsRequired();

            builder.Property(p => p.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(35)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.Address)
                .HasMaxLength(70)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.Number)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.Addition)
                .HasMaxLength(2)
                .IsUnicode(false);

            builder.Property(p => p.Zipcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.City)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(p => p.PhoneNr)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired(); ;

            builder.HasIndex(p => p.FederationNr).IsUnique();
        }
    }
}
