using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Data.Migrations
{
    public partial class DateTimeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Comment",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Comment",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Category",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Category",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Books",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Books",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Author",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Author",
                newName: "CreateAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Comment",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Comment",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Category",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Category",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Books",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Books",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Author",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Author",
                newName: "Created_at");
        }
    }
}
