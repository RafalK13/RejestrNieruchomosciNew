using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca47 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PlatnoscUW_Dzialka_DzialkaId",
            //    table: "PlatnoscUW");

            //migrationBuilder.DropIndex(
            //    name: "IX_PlatnoscUW_DzialkaId",
            //    table: "PlatnoscUW");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateIndex(
            //    name: "IX_PlatnoscUW_DzialkaId",
            //    table: "PlatnoscUW",
            //    column: "DzialkaId",
            //    unique: true,
            //    filter: "[DzialkaId] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PlatnoscUW_Dzialka_DzialkaId",
            //    table: "PlatnoscUW",
            //    column: "DzialkaId",
            //    principalTable: "Dzialka",
            //    principalColumn: "DzialkaId",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
