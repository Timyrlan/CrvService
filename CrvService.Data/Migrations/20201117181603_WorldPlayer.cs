using Microsoft.EntityFrameworkCore.Migrations;

namespace CrvService.Data.Migrations
{
    public partial class WorldPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserGuid",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorldId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_WorldId",
                table: "Players",
                column: "WorldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Worlds_WorldId",
                table: "Players",
                column: "WorldId",
                principalTable: "Worlds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Worlds_WorldId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_WorldId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WorldId",
                table: "Players");
        }
    }
}
