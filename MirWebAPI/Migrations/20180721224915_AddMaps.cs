using Microsoft.EntityFrameworkCore.Migrations;

namespace MirWebAPI.Migrations
{
    public partial class AddMaps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Map_MapId",
                table: "Monsters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Map",
                table: "Map");

            migrationBuilder.RenameTable(
                name: "Map",
                newName: "Maps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maps",
                table: "Maps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Maps_MapId",
                table: "Monsters",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Maps_MapId",
                table: "Monsters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maps",
                table: "Maps");

            migrationBuilder.RenameTable(
                name: "Maps",
                newName: "Map");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Map",
                table: "Map",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Map_MapId",
                table: "Monsters",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
