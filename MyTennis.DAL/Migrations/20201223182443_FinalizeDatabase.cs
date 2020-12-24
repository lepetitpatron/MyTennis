using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTennis.DAL.Migrations
{
    public partial class FinalizeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Result_GameId",
                table: "Result");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNr",
                table: "Member",
                unicode: false,
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldUnicode: false,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Member",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.CreateIndex(
                name: "IX_Result_GameId_SetNr",
                table: "Result",
                columns: new[] { "GameId", "SetNr" });

            // Generate stored procedure
            string resultsStoredProcedure = "CREATE PROCEDURE GetResults AS SELECT * FROM dbo.Result GO";
            migrationBuilder.Sql(resultsStoredProcedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Result_GameId_SetNr",
                table: "Result");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNr",
                table: "Member",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Member",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Result_GameId",
                table: "Result",
                column: "GameId");

            // Drop stored procedure
            migrationBuilder.Sql("DROP PROCEDURE GetResults");
        }
    }
}
