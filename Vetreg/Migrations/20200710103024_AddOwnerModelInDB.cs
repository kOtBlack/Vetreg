using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetreg.Migrations
{
    public partial class AddOwnerModelInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FIO = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owner_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id"
                        //onDelete: ReferentialAction.Cascade
                        );
                    table.ForeignKey(
                        name: "FK_Owner_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id"
                        //onDelete: ReferentialAction.Cascade
                        );
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owner_CityId",
                table: "Owner",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_RegionId",
                table: "Owner",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
