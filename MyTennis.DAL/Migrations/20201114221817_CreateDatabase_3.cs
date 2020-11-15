using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTennis.DAL.Migrations
{
    public partial class CreateDatabase_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

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
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FederationNr = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    GenderId = table.Column<byte>(nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    Number = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    Addition = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    Zipcode = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    City = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    PhoneNr = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameNumber = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MemberId = table.Column<int>(nullable: true),
                    LeagueId = table.Column<byte>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_League_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "League",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Man" },
                    { (byte)2, "Vrouw" }
                });

            migrationBuilder.InsertData(
                table: "League",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Recreatief" },
                    { (byte)2, "Competitie" },
                    { (byte)3, "Toptennis" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Voorzitter" },
                    { 2, "Bestuurslid" },
                    { 3, "Secretaris" },
                    { 4, "Penningmeester" },
                    { 5, "Speler" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameNumber",
                table: "Game",
                column: "GameNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_LeagueId",
                table: "Game",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_MemberId",
                table: "Game",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Gender_Name",
                table: "Gender",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_League_Name",
                table: "League",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_FederationNr",
                table: "Member",
                column: "FederationNr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_GenderId",
                table: "Member",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRole_RoleId",
                table: "MemberRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRole_MemberId_RoleId_StartDate_EndDate",
                table: "MemberRole",
                columns: new[] { "MemberId", "RoleId", "StartDate", "EndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Result_GameId",
                table: "Result",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                table: "Role",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fine");

            migrationBuilder.DropTable(
                name: "MemberRole");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "League");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
