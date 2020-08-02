using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetreg.Migrations
{
    public partial class newCascadaAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkWithAnimal_Animals_AnimalId",
                table: "WorkWithAnimal");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkWithAnimal_Works_WorkId",
                table: "WorkWithAnimal");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkWithAnimal_Animals_AnimalId",
                table: "WorkWithAnimal",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkWithAnimal_Works_WorkId",
                table: "WorkWithAnimal",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkWithAnimal_Animals_AnimalId",
                table: "WorkWithAnimal");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkWithAnimal_Works_WorkId",
                table: "WorkWithAnimal");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkWithAnimal_Animals_AnimalId",
                table: "WorkWithAnimal",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkWithAnimal_Works_WorkId",
                table: "WorkWithAnimal",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
