using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_NadzorKonserwSloId",
                table: "Dzialka",
                column: "NadzorKonserwSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dzialka_NadzorKonserwSlo_NadzorKonserwSloId",
                table: "Dzialka",
                column: "NadzorKonserwSloId",
                principalTable: "NadzorKonserwSlo",
                principalColumn: "NadzorKonserwSloId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dzialka_NadzorKonserwSlo_NadzorKonserwSloId",
                table: "Dzialka");

            migrationBuilder.DropIndex(
                name: "IX_Dzialka_NadzorKonserwSloId",
                table: "Dzialka");
        }
    }
}
