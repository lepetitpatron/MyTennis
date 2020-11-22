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
            builder.HasKey(sc => new { sc.Id });
        }
    }
}
