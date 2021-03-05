using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class addFilePropertyToBookFileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "BookFiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "BookFiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "BookFiles");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "BookFiles");
        }
    }
}
