using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.UI.Migrations
{
    public partial class _02Sep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lawsuit",
                table: "Documents",
                newName: "LawsuitId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_LawsuitId",
                table: "Documents",
                column: "LawsuitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Lawsuits_LawsuitId",
                table: "Documents",
                column: "LawsuitId",
                principalTable: "Lawsuits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Lawsuits_LawsuitId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_LawsuitId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "LawsuitId",
                table: "Documents",
                newName: "Lawsuit");
        }
    }
}
