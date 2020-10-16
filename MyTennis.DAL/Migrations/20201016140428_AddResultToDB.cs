using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTennis.DAL.Migrations
{
    public partial class AddResultToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(nullable: true),
                    SetNr = table.Column<byte>(unicode: false, maxLength: 3, nullable: false),
                    ScoreTeamMember = table.Column<byte>(unicode: false, maxLength: 3, nullable: false),
                    ScoreOpponent = table.Column<byte>(unicode: false, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Result_GameId",
                table: "Result",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Result");
        }
    }
}
