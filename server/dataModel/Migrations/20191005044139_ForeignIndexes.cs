using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class ForeignIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFavorite",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ParsedTextId",
                table: "UserFavorite",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EntityId",
                table: "UserCollectionItem",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CollectionId",
                table: "UserCollectionItem",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCollection",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "TextTag",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ParsedTextId",
                table: "TextTag",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ParsedTextId",
                table: "ParsedTextArtist",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MediaArtistId",
                table: "ParsedTextArtist",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MediaTextId",
                table: "ParsedText",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MediaId",
                table: "MediaText",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "MediaTag",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MediaId",
                table: "MediaTag",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MediaId",
                table: "MediaArtist",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorite_ParsedTextId",
                table: "UserFavorite",
                column: "ParsedTextId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorite_UserId",
                table: "UserFavorite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollectionItem_CollectionId",
                table: "UserCollectionItem",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollectionItem_EntityId",
                table: "UserCollectionItem",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollection_UserId",
                table: "UserCollection",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TextTag_ParsedTextId",
                table: "TextTag",
                column: "ParsedTextId");

            migrationBuilder.CreateIndex(
                name: "IX_TextTag_TagId",
                table: "TextTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ParsedTextArtist_MediaArtistId",
                table: "ParsedTextArtist",
                column: "MediaArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ParsedTextArtist_ParsedTextId",
                table: "ParsedTextArtist",
                column: "ParsedTextId");

            migrationBuilder.CreateIndex(
                name: "IX_ParsedText_MediaTextId",
                table: "ParsedText",
                column: "MediaTextId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaText_MediaId",
                table: "MediaText",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTag_MediaId",
                table: "MediaTag",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTag_TagId",
                table: "MediaTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaArtist_MediaId",
                table: "MediaArtist",
                column: "MediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserFavorite_ParsedTextId",
                table: "UserFavorite");

            migrationBuilder.DropIndex(
                name: "IX_UserFavorite_UserId",
                table: "UserFavorite");

            migrationBuilder.DropIndex(
                name: "IX_UserCollectionItem_CollectionId",
                table: "UserCollectionItem");

            migrationBuilder.DropIndex(
                name: "IX_UserCollectionItem_EntityId",
                table: "UserCollectionItem");

            migrationBuilder.DropIndex(
                name: "IX_UserCollection_UserId",
                table: "UserCollection");

            migrationBuilder.DropIndex(
                name: "IX_TextTag_ParsedTextId",
                table: "TextTag");

            migrationBuilder.DropIndex(
                name: "IX_TextTag_TagId",
                table: "TextTag");

            migrationBuilder.DropIndex(
                name: "IX_ParsedTextArtist_MediaArtistId",
                table: "ParsedTextArtist");

            migrationBuilder.DropIndex(
                name: "IX_ParsedTextArtist_ParsedTextId",
                table: "ParsedTextArtist");

            migrationBuilder.DropIndex(
                name: "IX_ParsedText_MediaTextId",
                table: "ParsedText");

            migrationBuilder.DropIndex(
                name: "IX_MediaText_MediaId",
                table: "MediaText");

            migrationBuilder.DropIndex(
                name: "IX_MediaTag_MediaId",
                table: "MediaTag");

            migrationBuilder.DropIndex(
                name: "IX_MediaTag_TagId",
                table: "MediaTag");

            migrationBuilder.DropIndex(
                name: "IX_MediaArtist_MediaId",
                table: "MediaArtist");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFavorite",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ParsedTextId",
                table: "UserFavorite",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EntityId",
                table: "UserCollectionItem",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CollectionId",
                table: "UserCollectionItem",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCollection",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "TextTag",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ParsedTextId",
                table: "TextTag",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ParsedTextId",
                table: "ParsedTextArtist",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MediaArtistId",
                table: "ParsedTextArtist",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MediaTextId",
                table: "ParsedText",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MediaId",
                table: "MediaText",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "MediaTag",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MediaId",
                table: "MediaTag",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MediaId",
                table: "MediaArtist",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
