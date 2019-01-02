using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class UserCollectionItem_And_UserCollectionFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCollections",
                table: "UserCollections");

            migrationBuilder.RenameTable(
                name: "UserCollections",
                newName: "UserCollection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCollection",
                table: "UserCollection",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserCollectionItem",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CollectionId = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: false),
                    EntityType = table.Column<string>(nullable: true),
                    Added = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCollectionItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCollectionItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCollection",
                table: "UserCollection");

            migrationBuilder.RenameTable(
                name: "UserCollection",
                newName: "UserCollections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCollections",
                table: "UserCollections",
                column: "Id");
        }
    }
}
