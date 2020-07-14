using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetreg.Migrations
{
    public partial class UpdateTagModelInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "AnimalId",
                table: "Tags",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Tags");
        }
    }
}
