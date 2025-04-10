using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Todo",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Todo",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Todo",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Todo");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Todo",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Todo",
                newName: "id");
        }
    }
}
