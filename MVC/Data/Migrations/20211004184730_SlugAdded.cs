using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Data.Migrations
{
    public partial class SlugAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Author",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Author");
        }
    }
}
