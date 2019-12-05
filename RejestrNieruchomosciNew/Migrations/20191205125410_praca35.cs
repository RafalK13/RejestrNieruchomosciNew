using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InnePrawa_DzialkaId",
                table: "InnePrawa",
                column: "DzialkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_InnePrawa_Dzialka_DzialkaId",
                table: "InnePrawa",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InnePrawa_Dzialka_DzialkaId",
                table: "InnePrawa");

            migrationBuilder.DropIndex(
                name: "IX_InnePrawa_DzialkaId",
                table: "InnePrawa");
        }
    }
}
