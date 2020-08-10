using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetreg.Migrations
{
    public partial class ChWorkModelDelOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Works_WorkGUID",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Works_WorkGUID",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_WorkGUID",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Animals_WorkGUID",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "WorkGUID",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "WorkGUID",
                table: "Animals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkGUID",
                table: "Owners",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkGUID",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_WorkGUID",
                table: "Owners",
                column: "WorkGUID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Works_WorkGUID",
                table: "Owners",
                column: "WorkGUID",
                principalTable: "Works",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
