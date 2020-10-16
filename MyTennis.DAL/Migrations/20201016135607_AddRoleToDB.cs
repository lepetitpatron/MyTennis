using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTennis.DAL.Migrations
{
    public partial class AddRoleToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FederationNr = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    GenderId = table.Column<byte>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Addition = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PhoneNr = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberRole_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_GenderId",
                table: "Member",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRole_MemberId",
                table: "MemberRole",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRole_RoleId",
                table: "MemberRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                table: "Role",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberRole");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
