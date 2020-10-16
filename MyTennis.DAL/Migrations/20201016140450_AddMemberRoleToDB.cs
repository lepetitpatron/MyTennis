using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTennis.DAL.Migrations
{
    public partial class AddMemberRoleToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberRole_MemberId",
                table: "MemberRole");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRole_MemberId_RoleId_StartDate_EndDate",
                table: "MemberRole",
                columns: new[] { "MemberId", "RoleId", "StartDate", "EndDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberRole_MemberId_RoleId_StartDate_EndDate",
                table: "MemberRole");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRole_MemberId",
                table: "MemberRole",
                column: "MemberId");
        }
    }
}
