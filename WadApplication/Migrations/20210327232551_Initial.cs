using Microsoft.EntityFrameworkCore.Migrations;

namespace WadApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllArtifacts",
                columns: table => new
                {
                    ArtifactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false),
                    Type = table.Column<string>(type: "varchar(20)", nullable: false),
                    SetName = table.Column<string>(type: "varchar(45)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllArtifacts", x => x.ArtifactID);
                });

            migrationBuilder.CreateTable(
                name: "AllCharacters",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(25)", nullable: false),
                    Vision = table.Column<string>(type: "varchar(10)", nullable: false),
                    WeaponType = table.Column<string>(type: "varchar(10)", nullable: true),
                    Nation = table.Column<string>(type: "varchar(15)", nullable: true),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllCharacters", x => x.CharacterID);
                });

            migrationBuilder.CreateTable(
                name: "AllWeapons",
                columns: table => new
                {
                    WeaponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false),
                    Type = table.Column<string>(type: "varchar(10)", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    SubStat = table.Column<string>(type: "varchar(35)", nullable: true),
                    SubStatValue = table.Column<int>(type: "int", nullable: false),
                    Passive = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllWeapons", x => x.WeaponID);
                });

            migrationBuilder.CreateTable(
                name: "ArtifactSets",
                columns: table => new
                {
                    SetName = table.Column<string>(type: "varchar(45)", nullable: false),
                    TwoPieceBonus = table.Column<string>(type: "text", nullable: false),
                    FourPieceBonus = table.Column<string>(type: "text", nullable: false),
                    MinRarity = table.Column<int>(type: "int", nullable: false),
                    MaxRarity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtifactSets", x => x.SetName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllArtifacts");

            migrationBuilder.DropTable(
                name: "AllCharacters");

            migrationBuilder.DropTable(
                name: "AllWeapons");

            migrationBuilder.DropTable(
                name: "ArtifactSets");
        }
    }
}
