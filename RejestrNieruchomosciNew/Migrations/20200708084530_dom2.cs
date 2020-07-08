using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Dzialka_BudynekId",
                table: "Adres");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_DzialkaId",
                table: "Adres",
                column: "DzialkaId",
                unique: true,
                filter: "[DzialkaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Dzialka_DzialkaId",
                table: "Adres",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Dzialka_DzialkaId",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_DzialkaId",
                table: "Adres");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Dzialka_BudynekId",
                table: "Adres",
                column: "BudynekId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
