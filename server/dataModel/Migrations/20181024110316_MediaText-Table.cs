using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class MediaTextTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaText",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MediaId = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaText", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaText");
        }
    }
}
