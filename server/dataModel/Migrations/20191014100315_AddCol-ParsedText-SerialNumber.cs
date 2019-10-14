using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class AddColParsedTextSerialNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerialNumber",
                table: "ParsedText",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "ParsedText");
        }
    }
}
