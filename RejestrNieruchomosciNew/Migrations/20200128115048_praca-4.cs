using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dzialka_NadzorKonserwSlo_NadzorKonserwSloId",
                table: "Dzialka");

            migrationBuilder.AlterColumn<int>(
                name: "NadzorKonserwSloId",
                table: "Dzialka",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Dzialka_NadzorKonserwSlo_NadzorKonserwSloId",
                table: "Dzialka",
                column: "NadzorKonserwSloId",
                principalTable: "NadzorKonserwSlo",
                principalColumn: "NadzorKonserwSloId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dzialka_NadzorKonserwSlo_NadzorKonserwSloId",
                table: "Dzialka");

            migrationBuilder.AlterColumn<int>(
                name: "NadzorKonserwSloId",
                table: "Dzialka",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dzialka_NadzorKonserwSlo_NadzorKonserwSloId",
                table: "Dzialka",
                column: "NadzorKonserwSloId",
                principalTable: "NadzorKonserwSlo",
                principalColumn: "NadzorKonserwSloId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
