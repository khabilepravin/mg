using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class AddedTableParsedTextArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParsedTextArtist",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MediaArtistId = table.Column<string>(nullable: false),
                    ParsedTextId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Created = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParsedTextArtist", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParsedTextArtist");
        }
    }
}
