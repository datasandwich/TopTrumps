using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopTrumps.Migrations
{
    public partial class DeckMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deckid = table.Column<int>(type: "int", nullable: false),
                    Attr1 = table.Column<int>(type: "nvarchar(max)", nullable: false),
                    Attr2 = table.Column<int>(type: "nvarchar(max)", nullable: false),
                    Attr3 = table.Column<int>(type: "nvarchar(max)", nullable: false),
                    Attr4 = table.Column<int>(type: "nvarchar(max)", nullable: false),
                    Attr5 = table.Column<int>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deckid = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attr1 = table.Column<int>(type: "int", nullable: false),
                    Attr2 = table.Column<int>(type: "int", nullable: false),
                    Attr3 = table.Column<int>(type: "int", nullable: false),
                    Attr4 = table.Column<int>(type: "int", nullable: false),
                    Attr5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Deck");
        }
    }
}
