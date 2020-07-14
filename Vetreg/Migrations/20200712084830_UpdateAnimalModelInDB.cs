using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetreg.Migrations
{
    public partial class UpdateAnimalModelInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Animals");

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "Animals",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Animals");

            migrationBuilder.AddColumn<byte>(
                name: "Sex",
                table: "Animals",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
