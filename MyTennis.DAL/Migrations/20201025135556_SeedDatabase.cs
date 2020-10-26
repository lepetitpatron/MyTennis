using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTennis.DAL.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Role (Name) Values ('Voorzitter')");
            migrationBuilder.Sql("INSERT INTO Role (Name) Values ('Bestuurslid')");
            migrationBuilder.Sql("INSERT INTO Role (Name) Values ('Secretaris')");
            migrationBuilder.Sql("INSERT INTO Role (Name) Values ('Penningmeester')");
            migrationBuilder.Sql("INSERT INTO Role (Name) Values ('Speler')");

            migrationBuilder.Sql("INSERT INTO Gender (Id, Name) Values (1, 'Man')");
            migrationBuilder.Sql("INSERT INTO Gender (Id, Name) Values (2, 'Vrouw')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Role DBCC CHECKIDENT (Role, RESEED, 0)");
            migrationBuilder.Sql("DELETE FROM Gender");
        }
    }
}
