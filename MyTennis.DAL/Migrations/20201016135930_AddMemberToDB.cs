using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTennis.DAL.Migrations
{
    public partial class AddMemberToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Zipcode",
                table: "Member",
                unicode: false,
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNr",
                table: "Member",
                unicode: false,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Member",
                unicode: false,
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Member",
                unicode: false,
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Member",
                unicode: false,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FederationNr",
                table: "Member",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Member",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Member",
                unicode: false,
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Addition",
                table: "Member",
                unicode: false,
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_FederationNr",
                table: "Member",
                column: "FederationNr",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Member_FederationNr",
                table: "Member");

            migrationBuilder.AlterColumn<string>(
                name: "Zipcode",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNr",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FederationNr",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Addition",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 2,
                oldNullable: true);
        }
    }
}
