using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTennis.DAL.Migrations
{
    public partial class AddFineToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FineNumber = table.Column<int>(unicode: false, maxLength: 10, nullable: false),
                    MemberId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(7,2)", unicode: false, nullable: false),
                    HandoutDate = table.Column<DateTime>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fine_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fine_FineNumber",
                table: "Fine",
                column: "FineNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fine_MemberId",
                table: "Fine",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fine");
        }
    }
}
