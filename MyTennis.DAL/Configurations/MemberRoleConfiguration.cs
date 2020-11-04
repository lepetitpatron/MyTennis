using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTennis.DAL.Entities;

namespace MyTennis.DAL.Configurations
{
    class MemberRoleConfiguration : IEntityTypeConfiguration<MemberRole>
    {
        public void Configure(EntityTypeBuilder<MemberRole> builder)
        {
            builder.ToTable("MemberRole");

            builder.HasIndex(sc => new { sc.MemberId, sc.RoleId, sc.StartDate, sc.EndDate });

            // Many to Many relations
            builder.HasKey(sc => new { sc.Id });

            builder.HasOne(sc => sc.Member)
                .WithMany(m => m.MemberRoles)
                .HasForeignKey(sc => sc.MemberId);

            builder.HasOne(sc => sc.Role)
               .WithMany(r => r.MemberRoles)
               .HasForeignKey(sc => sc.RoleId);
        }
    }
}
