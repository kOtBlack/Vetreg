using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetreg.Migrations
{
    public partial class ChDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Cause_CauseId",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cause",
                table: "Cause");

            migrationBuilder.RenameTable(
                name: "Cause",
                newName: "Causes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Causes",
                table: "Causes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Causes_CauseId",
                table: "Works",
                column: "CauseId",
                principalTable: "Causes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Causes_CauseId",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Causes",
                table: "Causes");

            migrationBuilder.RenameTable(
                name: "Causes",
                newName: "Cause");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cause",
                table: "Cause",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Cause_CauseId",
                table: "Works",
                column: "CauseId",
                principalTable: "Cause",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
