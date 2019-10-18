using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NabyciePrawaId",
                table: "Scan",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransakcjeId",
                table: "Scan",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scan_NabyciePrawaId",
                table: "Scan",
                column: "NabyciePrawaId");

            migrationBuilder.CreateIndex(
                name: "IX_Scan_TransakcjeId",
                table: "Scan",
                column: "TransakcjeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatnoscUW_DzialkaId",
                table: "PlatnoscUW",
                column: "DzialkaId",
                unique: true,
                filter: "[DzialkaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatnoscUW_Dzialka_DzialkaId",
                table: "PlatnoscUW",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scan_NabyciePrawa_NabyciePrawaId",
                table: "Scan",
                column: "NabyciePrawaId",
                principalTable: "NabyciePrawa",
                principalColumn: "NabyciePrawaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scan_Transakcje_TransakcjeId",
                table: "Scan",
                column: "TransakcjeId",
                principalTable: "Transakcje",
                principalColumn: "TransakcjeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatnoscUW_Dzialka_DzialkaId",
                table: "PlatnoscUW");

            migrationBuilder.DropForeignKey(
                name: "FK_Scan_NabyciePrawa_NabyciePrawaId",
                table: "Scan");

            migrationBuilder.DropForeignKey(
                name: "FK_Scan_Transakcje_TransakcjeId",
                table: "Scan");

            migrationBuilder.DropIndex(
                name: "IX_Scan_NabyciePrawaId",
                table: "Scan");

            migrationBuilder.DropIndex(
                name: "IX_Scan_TransakcjeId",
                table: "Scan");

            migrationBuilder.DropIndex(
                name: "IX_PlatnoscUW_DzialkaId",
                table: "PlatnoscUW");

            migrationBuilder.DropColumn(
                name: "NabyciePrawaId",
                table: "Scan");

            migrationBuilder.DropColumn(
                name: "TransakcjeId",
                table: "Scan");
        }
    }
}
