using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hairdresser.Migrations
{
    public partial class yeni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Customers",
                newName: "Address");
        }
    }
}
