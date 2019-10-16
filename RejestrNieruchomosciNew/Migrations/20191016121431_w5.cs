using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormaWladaniaSlo_Wladanie_WladanieId",
                table: "FormaWladaniaSlo");

            migrationBuilder.DropForeignKey(
                name: "FK_NazwaCzynnosciSlo_Wladanie_WladanieId",
                table: "NazwaCzynnosciSlo");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatnoscUw_Wladanie_WladanieId",
                table: "PlatnoscUw");

            migrationBuilder.DropForeignKey(
                name: "FK_Podmiot_Wladanie_WladanieId",
                table: "Podmiot");

            migrationBuilder.DropForeignKey(
                name: "FK_RodzajDokumentuSlo_Wladanie_WladanieId",
                table: "RodzajDokumentuSlo");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_RodzajDokumentuSlo_WladanieId",
                table: "RodzajDokumentuSlo");

            migrationBuilder.DropIndex(
                name: "IX_Podmiot_WladanieId",
                table: "Podmiot");

            migrationBuilder.DropIndex(
                name: "IX_PlatnoscUw_WladanieId",
                table: "PlatnoscUw");

            migrationBuilder.DropIndex(
                name: "IX_NazwaCzynnosciSlo_WladanieId",
                table: "NazwaCzynnosciSlo");

            migrationBuilder.DropIndex(
                name: "IX_FormaWladaniaSlo_WladanieId",
                table: "FormaWladaniaSlo");

            migrationBuilder.DropColumn(
                name: "WladanieId",
                table: "RodzajDokumentuSlo");

            migrationBuilder.DropColumn(
                name: "WladanieId",
                table: "Podmiot");

            migrationBuilder.DropColumn(
                name: "WladanieId",
                table: "PlatnoscUw");

            migrationBuilder.DropColumn(
                name: "WladanieId",
                table: "NazwaCzynnosciSlo");

            migrationBuilder.DropColumn(
                name: "WladanieId",
                table: "FormaWladaniaSlo");

            migrationBuilder.AddColumn<int>(
                name: "FormaWladaniaSloId",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NazwaCzynnosciSloId",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PodmiotId",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RodzajDokumentuSloId",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie",
                column: "DzialkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_FormaWladaniaSloId",
                table: "Wladanie",
                column: "FormaWladaniaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_NazwaCzynnosciSloId",
                table: "Wladanie",
                column: "NazwaCzynnosciSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_PlatnoscUwId",
                table: "Wladanie",
                column: "PlatnoscUwId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_PodmiotId",
                table: "Wladanie",
                column: "PodmiotId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_RodzajDokumentuSloId",
                table: "Wladanie",
                column: "RodzajDokumentuSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_FormaWladaniaSlo_FormaWladaniaSloId",
                table: "Wladanie",
                column: "FormaWladaniaSloId",
                principalTable: "FormaWladaniaSlo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_NazwaCzynnosciSlo_NazwaCzynnosciSloId",
                table: "Wladanie",
                column: "NazwaCzynnosciSloId",
                principalTable: "NazwaCzynnosciSlo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_PlatnoscUw_PlatnoscUwId",
                table: "Wladanie",
                column: "PlatnoscUwId",
                principalTable: "PlatnoscUw",
                principalColumn: "PlatnoscUwId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Podmiot_PodmiotId",
                table: "Wladanie",
                column: "PodmiotId",
                principalTable: "Podmiot",
                principalColumn: "PodmiotId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_RodzajDokumentuSlo_RodzajDokumentuSloId",
                table: "Wladanie",
                column: "RodzajDokumentuSloId",
                principalTable: "RodzajDokumentuSlo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_FormaWladaniaSlo_FormaWladaniaSloId",
                table: "Wladanie");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_NazwaCzynnosciSlo_NazwaCzynnosciSloId",
                table: "Wladanie");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_PlatnoscUw_PlatnoscUwId",
                table: "Wladanie");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Podmiot_PodmiotId",
                table: "Wladanie");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_RodzajDokumentuSlo_RodzajDokumentuSloId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_FormaWladaniaSloId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_NazwaCzynnosciSloId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_PlatnoscUwId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_PodmiotId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_RodzajDokumentuSloId",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "FormaWladaniaSloId",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "NazwaCzynnosciSloId",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "PodmiotId",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "RodzajDokumentuSloId",
                table: "Wladanie");

            migrationBuilder.AddColumn<int>(
                name: "WladanieId",
                table: "RodzajDokumentuSlo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WladanieId",
                table: "Podmiot",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WladanieId",
                table: "PlatnoscUw",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WladanieId",
                table: "NazwaCzynnosciSlo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WladanieId",
                table: "FormaWladaniaSlo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie",
                column: "DzialkaId",
                unique: true,
                filter: "[DzialkaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RodzajDokumentuSlo_WladanieId",
                table: "RodzajDokumentuSlo",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_Podmiot_WladanieId",
                table: "Podmiot",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatnoscUw_WladanieId",
                table: "PlatnoscUw",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_NazwaCzynnosciSlo_WladanieId",
                table: "NazwaCzynnosciSlo",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaWladaniaSlo_WladanieId",
                table: "FormaWladaniaSlo",
                column: "WladanieId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormaWladaniaSlo_Wladanie_WladanieId",
                table: "FormaWladaniaSlo",
                column: "WladanieId",
                principalTable: "Wladanie",
                principalColumn: "WladanieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NazwaCzynnosciSlo_Wladanie_WladanieId",
                table: "NazwaCzynnosciSlo",
                column: "WladanieId",
                principalTable: "Wladanie",
                principalColumn: "WladanieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatnoscUw_Wladanie_WladanieId",
                table: "PlatnoscUw",
                column: "WladanieId",
                principalTable: "Wladanie",
                principalColumn: "WladanieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Podmiot_Wladanie_WladanieId",
                table: "Podmiot",
                column: "WladanieId",
                principalTable: "Wladanie",
                principalColumn: "WladanieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RodzajDokumentuSlo_Wladanie_WladanieId",
                table: "RodzajDokumentuSlo",
                column: "WladanieId",
                principalTable: "Wladanie",
                principalColumn: "WladanieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
