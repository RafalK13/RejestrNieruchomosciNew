using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Dzialka_DzialkaId",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_DzialkaId",
                table: "Adres");

            migrationBuilder.DropColumn(
                name: "DzialkaId",
                table: "Budynek");

            migrationBuilder.RenameColumn(
                name: "powPiwnic",
                table: "Budynek",
                newName: "powZPiwnic");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Budynek",
                newName: "AdresId");

            migrationBuilder.AddColumn<bool>(
                name: "co",
                table: "Budynek",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "gaz",
                table: "Budynek",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "internet",
                table: "Budynek",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "kanDeszcz",
                table: "Budynek",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "kanLok",
                table: "Budynek",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "kanSan",
                table: "Budynek",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "opisKonstr",
                table: "Budynek",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "prad",
                table: "Budynek",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "tel",
                table: "Budynek",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "tv",
                table: "Budynek",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "woda",
                table: "Budynek",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BudynekId",
                table: "Adres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adres_BudynekId",
                table: "Adres",
                column: "BudynekId",
                unique: true,
                filter: "[BudynekId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Budynek_BudynekId",
                table: "Adres",
                column: "BudynekId",
                principalTable: "Budynek",
                principalColumn: "BudynekId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Dzialka_BudynekId",
                table: "Adres",
                column: "BudynekId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Budynek_BudynekId",
                table: "Adres");

            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Dzialka_BudynekId",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_BudynekId",
                table: "Adres");

            migrationBuilder.DropColumn(
                name: "co",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "gaz",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "internet",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "kanDeszcz",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "kanLok",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "kanSan",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "opisKonstr",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "prad",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "tel",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "tv",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "woda",
                table: "Budynek");

            migrationBuilder.DropColumn(
                name: "BudynekId",
                table: "Adres");

            migrationBuilder.RenameColumn(
                name: "powZPiwnic",
                table: "Budynek",
                newName: "powPiwnic");

            migrationBuilder.RenameColumn(
                name: "AdresId",
                table: "Budynek",
                newName: "MediaId");

            migrationBuilder.AddColumn<int>(
                name: "DzialkaId",
                table: "Budynek",
                nullable: false,
                defaultValue: 0);

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
    }
}
