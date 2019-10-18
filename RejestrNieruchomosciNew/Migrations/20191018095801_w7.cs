using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NabyciePrawa_Wladanie_WladanieId",
                table: "NabyciePrawa");

            migrationBuilder.DropForeignKey(
                name: "FK_Scan_NabyciePrawa_NabyciePrawaId",
                table: "Scan");

            migrationBuilder.DropForeignKey(
                name: "FK_Scan_Transakcje_TransakcjeId",
                table: "Scan");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_FormaWladaniaSlo_FormaWladaniaSloId",
                table: "Wladanie");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Transakcje_NabycieId",
                table: "Wladanie");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_RodzajDokumentuSlo_RodzajDokumentuSloId",
                table: "Wladanie");

            migrationBuilder.DropTable(
                name: "RodzajDokScanSlo");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_FormaWladaniaSloId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_NabycieId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_RodzajDokumentuSloId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Scan_NabyciePrawaId",
                table: "Scan");

            migrationBuilder.DropIndex(
                name: "IX_Scan_TransakcjeId",
                table: "Scan");

            migrationBuilder.DropIndex(
                name: "IX_NabyciePrawa_WladanieId",
                table: "NabyciePrawa");

            migrationBuilder.DropColumn(
                name: "NabyciePrawaId",
                table: "Scan");

            migrationBuilder.DropColumn(
                name: "TransakcjeId",
                table: "Scan");

            migrationBuilder.RenameColumn(
                name: "ZbycieId",
                table: "Wladanie",
                newName: "TransakcjeSloId");

            migrationBuilder.RenameColumn(
                name: "RodzajDokumentuSloId",
                table: "Wladanie",
                newName: "TransakcjaId");

            migrationBuilder.RenameColumn(
                name: "FormaWladaniaId",
                table: "Wladanie",
                newName: "NabyciePrawaId");

            migrationBuilder.RenameColumn(
                name: "numer",
                table: "Transakcje",
                newName: "Numer");

            migrationBuilder.RenameColumn(
                name: "RodzajCzynnosciSloId",
                table: "Transakcje",
                newName: "RodzajTransakcjiId");

            migrationBuilder.RenameColumn(
                name: "NabycieId",
                table: "Transakcje",
                newName: "RodzajCzynnosciId");

            migrationBuilder.RenameColumn(
                name: "TransakcjeId",
                table: "Transakcje",
                newName: "TransakcjeSloId");

            migrationBuilder.RenameColumn(
                name: "WladanieId",
                table: "NabyciePrawa",
                newName: "Skan");

            migrationBuilder.RenameColumn(
                name: "NumerPost",
                table: "NabyciePrawa",
                newName: "ProtokolPrzejecia");

            migrationBuilder.AddColumn<int>(
                name: "RodzajDokumentuSloId",
                table: "Transakcje",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RodzajTransakcjiSloId",
                table: "Transakcje",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skan",
                table: "Transakcje",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "rok1",
                table: "PlatnoscUW",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rok2",
                table: "PlatnoscUW",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rok3",
                table: "PlatnoscUW",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_NabyciePrawaId",
                table: "Wladanie",
                column: "NabyciePrawaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_TransakcjeSloId",
                table: "Wladanie",
                column: "TransakcjeSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcje_RodzajDokumentuSloId",
                table: "Transakcje",
                column: "RodzajDokumentuSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcje_RodzajTransakcjiSloId",
                table: "Transakcje",
                column: "RodzajTransakcjiSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transakcje_RodzajDokumentuSlo_RodzajDokumentuSloId",
                table: "Transakcje",
                column: "RodzajDokumentuSloId",
                principalTable: "RodzajDokumentuSlo",
                principalColumn: "RodzajDokumentuSloId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transakcje_RodzajTransakcjiSlo_RodzajTransakcjiSloId",
                table: "Transakcje",
                column: "RodzajTransakcjiSloId",
                principalTable: "RodzajTransakcjiSlo",
                principalColumn: "RodzajTransakcjiSloId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_NabyciePrawa_NabyciePrawaId",
                table: "Wladanie",
                column: "NabyciePrawaId",
                principalTable: "NabyciePrawa",
                principalColumn: "NabyciePrawaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Transakcje_TransakcjeSloId",
                table: "Wladanie",
                column: "TransakcjeSloId",
                principalTable: "Transakcje",
                principalColumn: "TransakcjeSloId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transakcje_RodzajDokumentuSlo_RodzajDokumentuSloId",
                table: "Transakcje");

            migrationBuilder.DropForeignKey(
                name: "FK_Transakcje_RodzajTransakcjiSlo_RodzajTransakcjiSloId",
                table: "Transakcje");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_NabyciePrawa_NabyciePrawaId",
                table: "Wladanie");

            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Transakcje_TransakcjeSloId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_NabyciePrawaId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_TransakcjeSloId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Transakcje_RodzajDokumentuSloId",
                table: "Transakcje");

            migrationBuilder.DropIndex(
                name: "IX_Transakcje_RodzajTransakcjiSloId",
                table: "Transakcje");

            migrationBuilder.DropColumn(
                name: "RodzajDokumentuSloId",
                table: "Transakcje");

            migrationBuilder.DropColumn(
                name: "RodzajTransakcjiSloId",
                table: "Transakcje");

            migrationBuilder.DropColumn(
                name: "Skan",
                table: "Transakcje");

            migrationBuilder.DropColumn(
                name: "rok1",
                table: "PlatnoscUW");

            migrationBuilder.DropColumn(
                name: "rok2",
                table: "PlatnoscUW");

            migrationBuilder.DropColumn(
                name: "rok3",
                table: "PlatnoscUW");

            migrationBuilder.RenameColumn(
                name: "TransakcjeSloId",
                table: "Wladanie",
                newName: "ZbycieId");

            migrationBuilder.RenameColumn(
                name: "TransakcjaId",
                table: "Wladanie",
                newName: "RodzajDokumentuSloId");

            migrationBuilder.RenameColumn(
                name: "NabyciePrawaId",
                table: "Wladanie",
                newName: "FormaWladaniaId");

            migrationBuilder.RenameColumn(
                name: "Numer",
                table: "Transakcje",
                newName: "numer");

            migrationBuilder.RenameColumn(
                name: "RodzajTransakcjiId",
                table: "Transakcje",
                newName: "RodzajCzynnosciSloId");

            migrationBuilder.RenameColumn(
                name: "RodzajCzynnosciId",
                table: "Transakcje",
                newName: "NabycieId");

            migrationBuilder.RenameColumn(
                name: "TransakcjeSloId",
                table: "Transakcje",
                newName: "TransakcjeId");

            migrationBuilder.RenameColumn(
                name: "Skan",
                table: "NabyciePrawa",
                newName: "WladanieId");

            migrationBuilder.RenameColumn(
                name: "ProtokolPrzejecia",
                table: "NabyciePrawa",
                newName: "NumerPost");

            migrationBuilder.AddColumn<int>(
                name: "NabyciePrawaId",
                table: "Scan",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransakcjeId",
                table: "Scan",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RodzajDokScanSlo",
                columns: table => new
                {
                    RodzajDokScanSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajDokScanSlo", x => x.RodzajDokScanSloId);
                });

            migrationBuilder.InsertData(
                table: "RodzajDokScanSlo",
                columns: new[] { "RodzajDokScanSloId", "Nazwa" },
                values: new object[] { 1, "-" });

            migrationBuilder.InsertData(
                table: "RodzajDokScanSlo",
                columns: new[] { "RodzajDokScanSloId", "Nazwa" },
                values: new object[] { 2, "Transakcje" });

            migrationBuilder.InsertData(
                table: "RodzajDokScanSlo",
                columns: new[] { "RodzajDokScanSloId", "Nazwa" },
                values: new object[] { 3, "Nabycie Prawa" });

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_FormaWladaniaSloId",
                table: "Wladanie",
                column: "FormaWladaniaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_NabycieId",
                table: "Wladanie",
                column: "NabycieId",
                unique: true,
                filter: "[NabycieId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_RodzajDokumentuSloId",
                table: "Wladanie",
                column: "RodzajDokumentuSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Scan_NabyciePrawaId",
                table: "Scan",
                column: "NabyciePrawaId");

            migrationBuilder.CreateIndex(
                name: "IX_Scan_TransakcjeId",
                table: "Scan",
                column: "TransakcjeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_FormaWladaniaSlo_FormaWladaniaSloId",
                table: "Wladanie",
                column: "FormaWladaniaSloId",
                principalTable: "FormaWladaniaSlo",
                principalColumn: "FormaWladaniaSloId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Transakcje_NabycieId",
                table: "Wladanie",
                column: "NabycieId",
                principalTable: "Transakcje",
                principalColumn: "TransakcjeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_RodzajDokumentuSlo_RodzajDokumentuSloId",
                table: "Wladanie",
                column: "RodzajDokumentuSloId",
                principalTable: "RodzajDokumentuSlo",
                principalColumn: "RodzajDokumentuSloId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
