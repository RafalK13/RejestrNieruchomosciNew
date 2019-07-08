using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class r13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Obreb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Obreb",
                nullable: false,
                defaultValue: 0);
        }
    }
}
