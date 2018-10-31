using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dataModel.Migrations
{
    public partial class ParsedTextStartTimeEndTimeTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Modified",
                table: "MediaText",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Created",
                table: "MediaText",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "MediaText",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "MediaText",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
