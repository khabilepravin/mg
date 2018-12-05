using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class GroupIdInParsedTextTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                table: "ParsedText",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "ParsedText");
        }
    }
}
