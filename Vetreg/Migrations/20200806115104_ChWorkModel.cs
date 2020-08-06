using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetreg.Migrations
{
    public partial class ChWorkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorkGUID",
                table: "Animals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_WorkGUID",
                table: "Animals",
                column: "WorkGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Works_WorkGUID",
                table: "Animals",
                column: "WorkGUID",
                principalTable: "Works",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Works_WorkGUID",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_WorkGUID",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "WorkGUID",
                table: "Animals");
        }
    }
}
