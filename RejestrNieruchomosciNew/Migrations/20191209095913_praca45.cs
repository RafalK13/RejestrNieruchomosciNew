using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "DzialkaId",
            //    table: "PlatnoscUW",
            //    nullable: true);

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
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PlatnoscUW_Dzialka_DzialkaId",
            //    table: "PlatnoscUW");

            //migrationBuilder.DropIndex(
            //    name: "IX_PlatnoscUW_DzialkaId",
            //    table: "PlatnoscUW");

            //migrationBuilder.DropColumn(
            //    name: "DzialkaId",
            //    table: "PlatnoscUW");
        }
    }
}
