using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MirWebAPI.Migrations
{
    public partial class Quests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NameKR = table.Column<string>(nullable: true),
                    IconUrl = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    Reward = table.Column<string>(nullable: true),
                    PrecedingQuest = table.Column<string>(nullable: true),
                    StartLocation = table.Column<string>(nullable: true),
                    CompleteLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quests");
        }
    }
}
