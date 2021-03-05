using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class FakeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "BookFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "BookFiles");
        }
    }
}
