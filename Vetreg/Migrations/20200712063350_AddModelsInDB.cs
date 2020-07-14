using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetreg.Migrations
{
    public partial class AddModelsInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owner_Cities_CityId",
                table: "Owner");

            migrationBuilder.DropForeignKey(
                name: "FK_Owner_Regions_RegionId",
                table: "Owner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owner",
                table: "Owner");

            migrationBuilder.RenameTable(
                name: "Owner",
                newName: "Owners");

            migrationBuilder.RenameIndex(
                name: "IX_Owner_RegionId",
                table: "Owners",
                newName: "IX_Owners_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Owner_CityId",
                table: "Owners",
                newName: "IX_Owners_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Causes",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Causes", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Kinds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    KindId = table.Column<int>(nullable: false),
                    BreedId = table.Column<int>(nullable: false),
                    SuitId = table.Column<int>(nullable: false),
                    Sticker = table.Column<int>(nullable: false),
                    ChipNumber = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<byte>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    IsRetired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Animals_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id"
                        //onDelete: ReferentialAction.Cascade
                        );
                    table.ForeignKey(
                        name: "FK_Animals_Kinds_KindId",
                        column: x => x.KindId,
                        principalTable: "Kinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id"
                        //onDelete: ReferentialAction.Cascade
                        );
                    table.ForeignKey(
                        name: "FK_Animals_Suits_SuitId",
                        column: x => x.SuitId,
                        principalTable: "Suits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AnimalGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Animals_AnimalGUID",
                        column: x => x.AnimalGUID,
                        principalTable: "Animals",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_BreedId",
                table: "Animals",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CityId",
                table: "Animals",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_KindId",
                table: "Animals",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnerId",
                table: "Animals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_RegionId",
                table: "Animals",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SuitId",
                table: "Animals",
                column: "SuitId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_AnimalGUID",
                table: "Tags",
                column: "AnimalGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Cities_CityId",
                table: "Owners",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id"
                //onDelete: ReferentialAction.Cascade
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Regions_RegionId",
                table: "Owners",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id"
                //onDelete: ReferentialAction.Cascade
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Cities_CityId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Regions_RegionId",
                table: "Owners");

            migrationBuilder.DropTable(
                name: "Causes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Kinds");

            migrationBuilder.DropTable(
                name: "Suits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Owner");

            migrationBuilder.RenameIndex(
                name: "IX_Owners_RegionId",
                table: "Owner",
                newName: "IX_Owner_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Owners_CityId",
                table: "Owner",
                newName: "IX_Owner_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owner",
                table: "Owner",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_Cities_CityId",
                table: "Owner",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_Regions_RegionId",
                table: "Owner",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
