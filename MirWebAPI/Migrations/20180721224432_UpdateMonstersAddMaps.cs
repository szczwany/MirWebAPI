using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MirWebAPI.Migrations
{
    public partial class UpdateMonstersAddMaps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Drop",
                table: "Monsters");

            migrationBuilder.RenameColumn(
                name: "NameKr",
                table: "Monsters",
                newName: "NameKR");

            migrationBuilder.AddColumn<int>(
                name: "MapId",
                table: "Monsters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NameKR = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_MapId",
                table: "Monsters",
                column: "MapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Map_MapId",
                table: "Monsters",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Map_MapId",
                table: "Monsters");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_MapId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "MapId",
                table: "Monsters");

            migrationBuilder.RenameColumn(
                name: "NameKR",
                table: "Monsters",
                newName: "NameKr");

            migrationBuilder.AddColumn<string>(
                name: "Drop",
                table: "Monsters",
                nullable: true);
        }
    }
}
