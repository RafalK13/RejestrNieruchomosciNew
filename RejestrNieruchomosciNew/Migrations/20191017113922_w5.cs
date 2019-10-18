using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_PlatnoscUW_PlatnoscUWId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_PlatnoscUWId",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "PlatnoscUWId",
                table: "Wladanie");

            migrationBuilder.AddColumn<int>(
                name: "NabycieId",
                table: "Transakcje",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NabyciePrawaId",
                table: "PlatnoscUW",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_NabycieId",
                table: "Wladanie",
                column: "NabycieId",
                unique: true,
                filter: "[NabycieId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlatnoscUW_NabyciePrawaId",
                table: "PlatnoscUW",
                column: "NabyciePrawaId");

            migrationBuilder.CreateIndex(
                name: "IX_NabyciePrawa_WladanieId",
                table: "NabyciePrawa",
                column: "WladanieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NabyciePrawa_Wladanie_WladanieId",
                table: "NabyciePrawa",
                column: "WladanieId",
                principalTable: "Wladanie",
                principalColumn: "WladanieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatnoscUW_NabyciePrawa_NabyciePrawaId",
                table: "PlatnoscUW",
                column: "NabyciePrawaId",
                principalTable: "NabyciePrawa",
                principalColumn: "NabyciePrawaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Transakcje_NabycieId",
                table: "Wladanie",
                column: "NabycieId",
                principalTable: "Transakcje",
                principalColumn: "TransakcjeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NabyciePrawa_Wladanie_WladanieId",
                table: "NabyciePrawa");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatnoscUW_NabyciePrawa_NabyciePrawaId",
                table: "PlatnoscUW");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Transakcje_NabycieId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_NabycieId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_PlatnoscUW_NabyciePrawaId",
                table: "PlatnoscUW");

            migrationBuilder.DropIndex(
                name: "IX_NabyciePrawa_WladanieId",
                table: "NabyciePrawa");

            migrationBuilder.DropColumn(
                name: "NabycieId",
                table: "Transakcje");

            migrationBuilder.DropColumn(
                name: "NabyciePrawaId",
                table: "PlatnoscUW");

            migrationBuilder.AddColumn<int>(
                name: "PlatnoscUWId",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_PlatnoscUWId",
                table: "Wladanie",
                column: "PlatnoscUWId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_PlatnoscUW_PlatnoscUWId",
                table: "Wladanie",
                column: "PlatnoscUWId",
                principalTable: "PlatnoscUW",
                principalColumn: "PlatnoscUWId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
