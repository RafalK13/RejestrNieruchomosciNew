using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RodzajCzynnosciId",
                table: "Transakcje");

            migrationBuilder.DropColumn(
                name: "RodzajDokumentuId",
                table: "Transakcje");

            migrationBuilder.RenameColumn(
                name: "RodzajTransakcjiId",
                table: "Transakcje",
                newName: "RodzajCzynnosciSloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RodzajCzynnosciSloId",
                table: "Transakcje",
                newName: "RodzajTransakcjiId");

            migrationBuilder.AddColumn<int>(
                name: "RodzajCzynnosciId",
                table: "Transakcje",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RodzajDokumentuId",
                table: "Transakcje",
                nullable: true);
        }
    }
}
