using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTennis.DAL.Migrations
{
    public partial class AddMemberToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FederationNr = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    GenderId = table.Column<byte>(nullable: true),
                    Address = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    Number = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    Addition = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    Zipcode = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    City = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    PhoneNr = table.Column<string>(unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_FederationNr",
                table: "Member",
                column: "FederationNr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_GenderId",
                table: "Member",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
