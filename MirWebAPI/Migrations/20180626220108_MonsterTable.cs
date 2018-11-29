using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MirWebAPI.Migrations
{
    public partial class MonsterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NameKr = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Alive = table.Column<string>(nullable: true),
                    Tame = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    Attack = table.Column<string>(nullable: true),
                    Defence = table.Column<string>(nullable: true),
                    Fire = table.Column<string>(nullable: true),
                    Cold = table.Column<string>(nullable: true),
                    Light = table.Column<string>(nullable: true),
                    Wind = table.Column<string>(nullable: true),
                    Holy = table.Column<string>(nullable: true),
                    Dark = table.Column<string>(nullable: true),
                    Phantom = table.Column<string>(nullable: true),
                    BC = table.Column<string>(nullable: true),
                    Drop = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
