using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class wladanie6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dzialka_Wladanie_WladanieId",
                table: "Dzialka");

            migrationBuilder.DropIndex(
                name: "IX_Dzialka_WladanieId",
                table: "Dzialka");

            migrationBuilder.DropColumn(
                name: "WladanieId",
                table: "Dzialka");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie",
                column: "DzialkaId",
                unique: true);

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

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie");

            migrationBuilder.AddColumn<int>(
                name: "WladanieId",
                table: "Dzialka",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_WladanieId",
                table: "Dzialka",
                column: "WladanieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dzialka_Wladanie_WladanieId",
                table: "Dzialka",
                column: "WladanieId",
                principalTable: "Wladanie",
                principalColumn: "WladanieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
