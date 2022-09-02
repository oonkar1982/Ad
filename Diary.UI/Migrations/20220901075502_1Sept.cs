using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.UI.Migrations
{
    public partial class _1Sept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "fileName",
                table: "Documents",
                newName: "FileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Documents",
                newName: "fileName");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
