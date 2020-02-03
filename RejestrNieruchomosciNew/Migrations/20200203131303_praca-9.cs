using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "funkcjaFin",
                table: "Dzialka");

            migrationBuilder.DropColumn(
                name: "funkcjaMiesz",
                table: "Dzialka");

            migrationBuilder.DropColumn(
                name: "funkcjaSpol",
                table: "Dzialka");

            migrationBuilder.DropColumn(
                name: "funkcjaUzytk",
                table: "Dzialka");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "funkcjaFin",
                table: "Dzialka",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "funkcjaMiesz",
                table: "Dzialka",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "funkcjaSpol",
                table: "Dzialka",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "funkcjaUzytk",
                table: "Dzialka",
                nullable: true);
        }
    }
}
