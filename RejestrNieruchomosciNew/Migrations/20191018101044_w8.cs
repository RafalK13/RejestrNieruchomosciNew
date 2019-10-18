using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_NazwaCzynnosciSlo_NazwaCzynnosciSloId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_NazwaCzynnosciSloId",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "NazwaCzynnosciSloId",
                table: "Wladanie");

            migrationBuilder.AddColumn<int>(
                name: "NazwaCzynnosciSloId",
                table: "Transakcje",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_FormaWladaniaSloId",
                table: "Wladanie",
                column: "FormaWladaniaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcje_NazwaCzynnosciSloId",
                table: "Transakcje",
                column: "NazwaCzynnosciSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transakcje_NazwaCzynnosciSlo_NazwaCzynnosciSloId",
                table: "Transakcje",
                column: "NazwaCzynnosciSloId",
                principalTable: "NazwaCzynnosciSlo",
                principalColumn: "NazwaCzynnosciSloId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_FormaWladaniaSlo_FormaWladaniaSloId",
                table: "Wladanie",
                column: "FormaWladaniaSloId",
                principalTable: "FormaWladaniaSlo",
                principalColumn: "FormaWladaniaSloId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transakcje_NazwaCzynnosciSlo_NazwaCzynnosciSloId",
                table: "Transakcje");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_FormaWladaniaSlo_FormaWladaniaSloId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_FormaWladaniaSloId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Transakcje_NazwaCzynnosciSloId",
                table: "Transakcje");

            migrationBuilder.DropColumn(
                name: "NazwaCzynnosciSloId",
                table: "Transakcje");

            migrationBuilder.AddColumn<int>(
                name: "NazwaCzynnosciSloId",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_NazwaCzynnosciSloId",
                table: "Wladanie",
                column: "NazwaCzynnosciSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_NazwaCzynnosciSlo_NazwaCzynnosciSloId",
                table: "Wladanie",
                column: "NazwaCzynnosciSloId",
                principalTable: "NazwaCzynnosciSlo",
                principalColumn: "NazwaCzynnosciSloId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
