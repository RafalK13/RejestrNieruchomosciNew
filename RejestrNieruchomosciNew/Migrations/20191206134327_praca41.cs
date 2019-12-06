using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatnoscUW_Dzialka_DzialkaId",
                table: "PlatnoscUW");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatnoscUW_Dzialka_DzialkaId",
                table: "PlatnoscUW",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatnoscUW_Dzialka_DzialkaId",
                table: "PlatnoscUW");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatnoscUW_Dzialka_DzialkaId",
                table: "PlatnoscUW",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
