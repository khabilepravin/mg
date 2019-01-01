using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class MediaArtistTable_Rename_Rollback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityArtist");

            migrationBuilder.CreateTable(
                name: "MediaArtist",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MediaId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PersonName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ExternalLink = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaArtist", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaArtist");

            migrationBuilder.CreateTable(
                name: "EntityArtist",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ArtistCharacterName = table.Column<string>(nullable: true),
                    ArtistName = table.Column<string>(nullable: true),
                    ArtistType = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    EntityId = table.Column<string>(nullable: false),
                    EntityType = table.Column<string>(nullable: true),
                    ExternalLink = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityArtist", x => x.Id);
                });
        }
    }
}
