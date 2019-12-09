using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca43 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Dzialka_DzialkaId",
                table: "Wladanie");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Dzialka_DzialkaId",
                table: "Wladanie",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Dzialka_DzialkaId",
                table: "Wladanie");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Dzialka_DzialkaId",
                table: "Wladanie",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
