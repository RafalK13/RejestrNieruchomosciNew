using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "PlatnoscUWId",
            //    table: "Dzialka",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PlatnoscUW_DzialkaId",
            //    table: "PlatnoscUW",
            //    column: "DzialkaId",
            //    unique: true,
            //    filter: "[DzialkaId] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dzialka_PlatnoscUWId",
            //    table: "Dzialka",
            //    column: "PlatnoscUWId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Dzialka_PlatnoscUW_PlatnoscUWId",
            //    table: "Dzialka",
            //    column: "PlatnoscUWId",
            //    principalTable: "PlatnoscUW",
            //    principalColumn: "PlatnoscUWId",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PlatnoscUW_Dzialka_DzialkaId",
            //    table: "PlatnoscUW",
            //    column: "DzialkaId",
            //    principalTable: "Dzialka",
            //    principalColumn: "DzialkaId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Dzialka_PlatnoscUW_PlatnoscUWId",
        //        table: "Dzialka");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_PlatnoscUW_Dzialka_DzialkaId",
        //        table: "PlatnoscUW");

        //    migrationBuilder.DropIndex(
        //        name: "IX_PlatnoscUW_DzialkaId",
        //        table: "PlatnoscUW");

        //    migrationBuilder.DropIndex(
        //        name: "IX_Dzialka_PlatnoscUWId",
        //        table: "Dzialka");

        //    migrationBuilder.DropColumn(
        //        name: "PlatnoscUWId",
        //        table: "Dzialka");
        }
    }
}
