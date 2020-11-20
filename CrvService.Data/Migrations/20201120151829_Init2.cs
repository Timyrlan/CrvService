using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrvService.Data.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientCommands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorldId = table.Column<int>(nullable: false),
                    WorldGuid = table.Column<string>(nullable: true),
                    PlayerId = table.Column<int>(nullable: false),
                    PlayerGuid = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    Processed = table.Column<bool>(nullable: false),
                    ProcessDateTime = table.Column<DateTime>(nullable: true),
                    Guid = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ToX = table.Column<float>(nullable: true),
                    ToY = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Worlds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    WorldDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worlds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Size = table.Column<float>(nullable: false),
                    X = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    WorldEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Worlds_WorldEntityId",
                        column: x => x.WorldEntityId,
                        principalTable: "Worlds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VisibleCitiesStr = table.Column<string>(nullable: true),
                    WorldId = table.Column<int>(nullable: true),
                    Guid = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UserGuid = table.Column<string>(nullable: true),
                    X = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false),
                    IsMoving = table.Column<bool>(nullable: false),
                    MoveToX = table.Column<float>(nullable: false),
                    MoveToY = table.Column<float>(nullable: false),
                    WorldGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Worlds_WorldId",
                        column: x => x.WorldId,
                        principalTable: "Worlds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CityEntityId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Cities_CityEntityId",
                        column: x => x.CityEntityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServerCommands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorldGuid = table.Column<string>(nullable: true),
                    PlayerId = table.Column<int>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    PlayerGuid = table.Column<string>(nullable: true),
                    Guid = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: false),
                    ProcessDateTime = table.Column<DateTime>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CityGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerCommands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServerCommands_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<decimal>(nullable: false),
                    Guid = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    BuildingEntityId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_Buildings_BuildingEntityId",
                        column: x => x.BuildingEntityId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CityEntityId",
                table: "Buildings",
                column: "CityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_BuildingEntityId",
                table: "Cargos",
                column: "BuildingEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_WorldEntityId",
                table: "Cities",
                column: "WorldEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_WorldId",
                table: "Players",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerCommands_PlayerId",
                table: "ServerCommands",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "ClientCommands");

            migrationBuilder.DropTable(
                name: "ServerCommands");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Worlds");
        }
    }
}
