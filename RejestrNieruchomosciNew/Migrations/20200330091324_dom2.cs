using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dzialka_Budynek",
                table: "Dzialka_Budynek");

            migrationBuilder.DropIndex(
                name: "IX_Dzialka_Budynek_DzialkaId",
                table: "Dzialka_Budynek");

            migrationBuilder.RenameColumn(
                name: "NumerEwid",
                table: "Budynek",
                newName: "numerEwid");

            migrationBuilder.AddColumn<string>(
                name: "Nazwa",
                table: "Budynek",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dzialka_Budynek",
                table: "Dzialka_Budynek",
                columns: new[] { "DzialkaId", "BudynekId" });

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_Budynek_BudynekId",
                table: "Dzialka_Budynek",
                column: "BudynekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dzialka_Budynek",
                table: "Dzialka_Budynek");

            migrationBuilder.DropIndex(
                name: "IX_Dzialka_Budynek_BudynekId",
                table: "Dzialka_Budynek");

            migrationBuilder.DropColumn(
                name: "Nazwa",
                table: "Budynek");

            migrationBuilder.RenameColumn(
                name: "numerEwid",
                table: "Budynek",
                newName: "NumerEwid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dzialka_Budynek",
                table: "Dzialka_Budynek",
                columns: new[] { "BudynekId", "DzialkaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_Budynek_DzialkaId",
                table: "Dzialka_Budynek",
                column: "DzialkaId");
        }
    }
}
