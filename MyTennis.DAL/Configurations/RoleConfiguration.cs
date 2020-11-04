using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTennis.DAL.Entities;

namespace MyTennis.DAL.Configurations
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.Property(p => p.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.HasIndex(p => p.Name).IsUnique();

            builder.HasData(new Role { Id=1, Name = "Voorzitter" });
            builder.HasData(new Role { Id=2, Name = "Bestuurslid" });
            builder.HasData(new Role { Id=3, Name = "Secretaris" });
            builder.HasData(new Role { Id=4, Name = "Penningmeester" });
            builder.HasData(new Role { Id=5, Name = "Speler" });
        }
    }
}
