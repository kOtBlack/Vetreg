using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetreg.Data.Migrations
{
    public partial class AddModelInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cause",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cause", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Chief = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kind", x => x.Id);
                });

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
                    RegionId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owner_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Owner_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    RegionId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    OwnerId = table.Column<int>(nullable: true),
                    EventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Work_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Work_Cause_EventId",
                        column: x => x.EventId,
                        principalTable: "Cause",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Work_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Work_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    RegionId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    OwnerId = table.Column<int>(nullable: true),
                    KindId = table.Column<int>(nullable: true),
                    BreedId = table.Column<int>(nullable: true),
                    SuitId = table.Column<int>(nullable: true),
                    Sticker = table.Column<int>(nullable: false),
                    ChipNumber = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<byte>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    IsRetired = table.Column<bool>(nullable: false),
                    WorkGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Animal_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Kind_KindId",
                        column: x => x.KindId,
                        principalTable: "Kind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Suit_SuitId",
                        column: x => x.SuitId,
                        principalTable: "Suit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Work_WorkGUID",
                        column: x => x.WorkGUID,
                        principalTable: "Work",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AnimalGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Animal_AnimalGUID",
                        column: x => x.AnimalGUID,
                        principalTable: "Animal",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_BreedId",
                table: "Animal",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_CityId",
                table: "Animal",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_KindId",
                table: "Animal",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_OwnerId",
                table: "Animal",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_RegionId",
                table: "Animal",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_SuitId",
                table: "Animal",
                column: "SuitId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_WorkGUID",
                table: "Animal",
                column: "WorkGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CityId",
                table: "Company",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_RegionId",
                table: "Company",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_CityId",
                table: "Owner",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_RegionId",
                table: "Owner",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_AnimalGUID",
                table: "Tag",
                column: "AnimalGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Work_CityId",
                table: "Work",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_EventId",
                table: "Work",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_OwnerId",
                table: "Work",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_RegionId",
                table: "Work",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "Kind");

            migrationBuilder.DropTable(
                name: "Suit");

            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropTable(
                name: "Cause");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
