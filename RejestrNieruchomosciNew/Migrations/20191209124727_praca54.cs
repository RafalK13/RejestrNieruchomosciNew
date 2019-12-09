using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca54 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InnePrawa_Dzialka_DzialkaId",
                table: "InnePrawa");

            migrationBuilder.AddForeignKey(
                name: "FK_InnePrawa_Dzialka_DzialkaId",
                table: "InnePrawa",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InnePrawa_Dzialka_DzialkaId",
                table: "InnePrawa");

            migrationBuilder.AddForeignKey(
                name: "FK_InnePrawa_Dzialka_DzialkaId",
                table: "InnePrawa",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
