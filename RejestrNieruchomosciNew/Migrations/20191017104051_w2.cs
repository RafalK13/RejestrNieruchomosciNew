using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RodzajCzynnosciSlo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NazwaCzynnosciSlo",
                newName: "NazwaCzynnosciSloId");

            migrationBuilder.CreateTable(
                name: "RodzajTransakcjiSlo",
                columns: table => new
                {
                    RodzajTransakcjiSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajTransakcjiSlo", x => x.RodzajTransakcjiSloId);
                });

            migrationBuilder.UpdateData(
                table: "FormaWladaniaSlo",
                keyColumn: "FormaWladaniaSloId",
                keyValue: 1,
                column: "Nazwa",
                value: "-");

            migrationBuilder.UpdateData(
                table: "FormaWladaniaSlo",
                keyColumn: "FormaWladaniaSloId",
                keyValue: 2,
                column: "Nazwa",
                value: "Własność");

            migrationBuilder.InsertData(
                table: "FormaWladaniaSlo",
                columns: new[] { "FormaWladaniaSloId", "Nazwa" },
                values: new object[] { 3, "UW" });

            migrationBuilder.InsertData(
                table: "NazwaCzynnosciSlo",
                columns: new[] { "NazwaCzynnosciSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "Zakup" },
                    { 3, "Aport" }
                });

            migrationBuilder.UpdateData(
                table: "RodzajDokScanSlo",
                keyColumn: "RodzajDokScanSloId",
                keyValue: 1,
                column: "Nazwa",
                value: "-");

            migrationBuilder.UpdateData(
                table: "RodzajDokScanSlo",
                keyColumn: "RodzajDokScanSloId",
                keyValue: 2,
                column: "Nazwa",
                value: "Transakcje");

            migrationBuilder.InsertData(
                table: "RodzajDokScanSlo",
                columns: new[] { "RodzajDokScanSloId", "Nazwa" },
                values: new object[] { 3, "Nabycie Prawa" });

            migrationBuilder.UpdateData(
                table: "RodzajDokumentuSlo",
                keyColumn: "RodzajDokumentuSloId",
                keyValue: 1,
                column: "Nazwa",
                value: "-");

            migrationBuilder.UpdateData(
                table: "RodzajDokumentuSlo",
                keyColumn: "RodzajDokumentuSloId",
                keyValue: 2,
                column: "Nazwa",
                value: "Akt notarialny");

            migrationBuilder.InsertData(
                table: "RodzajDokumentuSlo",
                columns: new[] { "RodzajDokumentuSloId", "Nazwa" },
                values: new object[] { 3, "Postanowienie sądu" });

            migrationBuilder.InsertData(
                table: "RodzajTransakcjiSlo",
                columns: new[] { "RodzajTransakcjiSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "Kupno" },
                    { 3, "Sprzedaż" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RodzajTransakcjiSlo");

            migrationBuilder.DeleteData(
                table: "FormaWladaniaSlo",
                keyColumn: "FormaWladaniaSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NazwaCzynnosciSlo",
                keyColumn: "NazwaCzynnosciSloId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NazwaCzynnosciSlo",
                keyColumn: "NazwaCzynnosciSloId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NazwaCzynnosciSlo",
                keyColumn: "NazwaCzynnosciSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RodzajDokScanSlo",
                keyColumn: "RodzajDokScanSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RodzajDokumentuSlo",
                keyColumn: "RodzajDokumentuSloId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "NazwaCzynnosciSloId",
                table: "NazwaCzynnosciSlo",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "RodzajCzynnosciSlo",
                columns: table => new
                {
                    RodzajCzynnosciSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajCzynnosciSlo", x => x.RodzajCzynnosciSloId);
                });

            migrationBuilder.UpdateData(
                table: "FormaWladaniaSlo",
                keyColumn: "FormaWladaniaSloId",
                keyValue: 1,
                column: "Nazwa",
                value: "Własność");

            migrationBuilder.UpdateData(
                table: "FormaWladaniaSlo",
                keyColumn: "FormaWladaniaSloId",
                keyValue: 2,
                column: "Nazwa",
                value: "UW");

            migrationBuilder.InsertData(
                table: "RodzajCzynnosciSlo",
                columns: new[] { "RodzajCzynnosciSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Kupno" },
                    { 2, "Sprzedaż" }
                });

            migrationBuilder.UpdateData(
                table: "RodzajDokScanSlo",
                keyColumn: "RodzajDokScanSloId",
                keyValue: 1,
                column: "Nazwa",
                value: "Transakcje");

            migrationBuilder.UpdateData(
                table: "RodzajDokScanSlo",
                keyColumn: "RodzajDokScanSloId",
                keyValue: 2,
                column: "Nazwa",
                value: "Nabycie Prawa");

            migrationBuilder.UpdateData(
                table: "RodzajDokumentuSlo",
                keyColumn: "RodzajDokumentuSloId",
                keyValue: 1,
                column: "Nazwa",
                value: "Akt notarialny");

            migrationBuilder.UpdateData(
                table: "RodzajDokumentuSlo",
                keyColumn: "RodzajDokumentuSloId",
                keyValue: 2,
                column: "Nazwa",
                value: "Postanowienie sądu");
        }
    }
}
