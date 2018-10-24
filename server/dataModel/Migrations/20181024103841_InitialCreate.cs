using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Season = table.Column<string>(nullable: true),
                    Episode = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ExternalLink = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Media");
        }
    }
}
