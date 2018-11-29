using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MirWebAPI.Migrations
{
    public partial class AddMapTypeAndMapRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MapRangeId",
                table: "Maps",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MapTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NameKR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelRange = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionKR = table.Column<string>(nullable: true),
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
                name: "IX_Maps_MapRangeId",
                table: "Maps",
                column: "MapRangeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_MapRanges_MapRangeId",
                table: "Maps");

            migrationBuilder.DropTable(
                name: "MapRanges");

            migrationBuilder.DropTable(
                name: "MapTypes");

            migrationBuilder.DropIndex(
                name: "IX_Maps_MapRangeId",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "MapRangeId",
                table: "Maps");
        }
    }
}
