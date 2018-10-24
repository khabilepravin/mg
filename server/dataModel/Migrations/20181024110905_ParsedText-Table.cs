using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class ParsedTextTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParsedText",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MediaTextId = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    ArtistId = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParsedText", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParsedText");
        }
    }
}
