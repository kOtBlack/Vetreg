using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetreg.Migrations
{
    public partial class AddCause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Causes_CauseGUID",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Owners_OwnerId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_CauseGUID",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_OwnerId",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Causes",
                table: "Causes");

            migrationBuilder.DropColumn(
                name: "CauseGUID",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "GUID",
                table: "Causes");

            migrationBuilder.AlterColumn<int>(
                name: "CauseId",
                table: "Works",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkGUID",
                table: "Owners",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Causes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Causes",
                table: "Causes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Works_CauseId",
                table: "Works",
                column: "CauseId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_WorkGUID",
                table: "Owners",
                column: "WorkGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Works_WorkGUID",
                table: "Owners",
                column: "WorkGUID",
                principalTable: "Works",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Owners_Works_WorkGUID",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Causes_CauseId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_CauseId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Owners_WorkGUID",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Causes",
                table: "Causes");

            migrationBuilder.DropColumn(
                name: "WorkGUID",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Causes");

            migrationBuilder.AlterColumn<string>(
                name: "CauseId",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<Guid>(
                name: "CauseGUID",
                table: "Works",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GUID",
                table: "Causes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Causes",
                table: "Causes",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "IX_Works_CauseGUID",
                table: "Works",
                column: "CauseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Works_OwnerId",
                table: "Works",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Causes_CauseGUID",
                table: "Works",
                column: "CauseGUID",
                principalTable: "Causes",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Owners_OwnerId",
                table: "Works",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
