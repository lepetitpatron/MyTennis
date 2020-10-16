using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTennis.DAL.Migrations
{
    public partial class AddLeagueToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_League_Name",
                table: "League",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "League");
        }
    }
}
