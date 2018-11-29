using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MirWebAPI.Migrations
{
    public partial class SchemaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_MapRanges_MapRangeId",
                table: "Maps");

            migrationBuilder.DropTable(
                name: "MapRanges");

            migrationBuilder.RenameColumn(
                name: "NameKR",
                table: "MapTypes",
                newName: "LevelRange");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MapTypes",
                newName: "DescriptionKR");

            migrationBuilder.RenameColumn(
                name: "MapRangeId",
                table: "Maps",
                newName: "MapTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_MapRangeId",
                table: "Maps",
                newName: "IX_Maps_MapTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MapTypes",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_MapTypes_MapTypeId",
                table: "Maps",
                column: "MapTypeId",
                principalTable: "MapTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_MapTypes_MapTypeId",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MapTypes");

            migrationBuilder.RenameColumn(
                name: "LevelRange",
                table: "MapTypes",
                newName: "NameKR");

            migrationBuilder.RenameColumn(
                name: "DescriptionKR",
                table: "MapTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MapTypeId",
                table: "Maps",
                newName: "MapRangeId");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_MapTypeId",
                table: "Maps",
                newName: "IX_Maps_MapRangeId");

            migrationBuilder.CreateTable(
                name: "MapRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    DescriptionKR = table.Column<string>(nullable: true),
                    LevelRange = table.Column<string>(nullable: true),
                    MapTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapRanges_MapTypes_MapTypeId",
                        column: x => x.MapTypeId,
                        principalTable: "MapTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapRanges_MapTypeId",
                table: "MapRanges",
                column: "MapTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_MapRanges_MapRangeId",
                table: "Maps",
                column: "MapRangeId",
                principalTable: "MapRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
