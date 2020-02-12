using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UliceSloId",
                table: "Dzialka",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_UliceSloId",
                table: "Dzialka",
                column: "UliceSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dzialka_UliceSlo_UliceSloId",
                table: "Dzialka",
                column: "UliceSloId",
                principalTable: "UliceSlo",
                principalColumn: "UliceSloId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dzialka_UliceSlo_UliceSloId",
                table: "Dzialka");

            migrationBuilder.DropIndex(
                name: "IX_Dzialka_UliceSloId",
                table: "Dzialka");

            migrationBuilder.DropColumn(
                name: "UliceSloId",
                table: "Dzialka");
        }
    }
}
