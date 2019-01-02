using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class TextTagTableIntroduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextTag",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ParsedTextId = table.Column<string>(nullable: false),
                    TagId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextTag", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextTag");
        }
    }
}
