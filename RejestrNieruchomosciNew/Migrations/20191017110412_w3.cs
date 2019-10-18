using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_PlatnoscUw_PlatnoscUWId",
                table: "Wladanie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatnoscUw",
                table: "PlatnoscUw");

            migrationBuilder.RenameTable(
                name: "PlatnoscUw",
                newName: "PlatnoscUW");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatnoscUW",
                table: "PlatnoscUW",
                column: "PlatnoscUWId");

            migrationBuilder.CreateTable(
                name: "NabyciePrawa",
                columns: table => new
                {
                    NabyciePrawaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WladanieId = table.Column<int>(nullable: false),
                    ObowiazywanieOd = table.Column<DateTime>(nullable: false),
                    ObowiazywanieDo = table.Column<DateTime>(nullable: false),
                    NumerPost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabyciePrawa", x => x.NabyciePrawaId);
                });

            migrationBuilder.CreateTable(
                name: "Scan",
                columns: table => new
                {
                    ScanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RodzajDokScanSloId = table.Column<int>(nullable: false),
                    RodzajId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scan", x => x.ScanId);
                });

            migrationBuilder.CreateTable(
                name: "Transakcje",
                columns: table => new
                {
                    TransakcjeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RodzajDokumentuId = table.Column<int>(nullable: false),
                    RodzajCzynnosciSloId = table.Column<int>(nullable: false),
                    numer = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Tytul = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcje", x => x.TransakcjeId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_PlatnoscUW_PlatnoscUWId",
                table: "Wladanie",
                column: "PlatnoscUWId",
                principalTable: "PlatnoscUW",
                principalColumn: "PlatnoscUWId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_PlatnoscUW_PlatnoscUWId",
                table: "Wladanie");

            migrationBuilder.DropTable(
                name: "NabyciePrawa");

            migrationBuilder.DropTable(
                name: "Scan");

            migrationBuilder.DropTable(
                name: "Transakcje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatnoscUW",
                table: "PlatnoscUW");

            migrationBuilder.RenameTable(
                name: "PlatnoscUW",
                newName: "PlatnoscUw");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatnoscUw",
                table: "PlatnoscUw",
                column: "PlatnoscUWId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_PlatnoscUw_PlatnoscUWId",
                table: "Wladanie",
                column: "PlatnoscUWId",
                principalTable: "PlatnoscUw",
                principalColumn: "PlatnoscUWId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
