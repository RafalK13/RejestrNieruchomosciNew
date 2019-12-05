using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DecyzjeAdministracyjne",
                columns: table => new
                {
                    DecyzjeAdministracyjneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numer = table.Column<string>(nullable: true),
                    DataDecyzji = table.Column<DateTime>(nullable: true),
                    PodmiotId = table.Column<int>(nullable: true),
                    Przedmiot = table.Column<string>(nullable: true),
                    Skan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecyzjeAdministracyjne", x => x.DecyzjeAdministracyjneId);
                });

            migrationBuilder.CreateTable(
                name: "RodzajInnegoPrawaSlo",
                columns: table => new
                {
                    RodzajInnegoPrawaSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajInnegoPrawaSlo", x => x.RodzajInnegoPrawaSloId);
                });

            migrationBuilder.CreateTable(
                name: "InnePrawa",
                columns: table => new
                {
                    InnePrawaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: true),
                    PodmiotId = table.Column<int>(nullable: true),
                    RodzajInnegoPrawaSloId = table.Column<int>(nullable: true),
                    DataObowOd = table.Column<DateTime>(nullable: true),
                    DataObowDo = table.Column<DateTime>(nullable: true),
                    ProtPrzejkNr = table.Column<string>(nullable: true),
                    ProtPrzejData = table.Column<DateTime>(nullable: true),
                    ProtPrzejScan = table.Column<string>(nullable: true),
                    ProtZwrotNr = table.Column<string>(nullable: true),
                    ProtZwrotData = table.Column<DateTime>(nullable: true),
                    ProtZwrotScan = table.Column<string>(nullable: true),
                    wizjaTerPrzek = table.Column<DateTime>(nullable: true),
                    wizjaTerZwrot = table.Column<DateTime>(nullable: true),
                    CelNabyciaId = table.Column<int>(nullable: true),
                    WarunkiRealizacji = table.Column<string>(nullable: true),
                    DecyzjeAdministracyjneId = table.Column<int>(nullable: true),
                    TransK_Id = table.Column<int>(nullable: true),
                    TransS_Id = table.Column<int>(nullable: true),
                    PlatnosciId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnePrawa", x => x.InnePrawaId);
                    table.ForeignKey(
                        name: "FK_InnePrawa_RodzajInnegoPrawaSlo_RodzajInnegoPrawaSloId",
                        column: x => x.RodzajInnegoPrawaSloId,
                        principalTable: "RodzajInnegoPrawaSlo",
                        principalColumn: "RodzajInnegoPrawaSloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InnePrawa_Transakcje_TransK_Id",
                        column: x => x.TransK_Id,
                        principalTable: "Transakcje",
                        principalColumn: "TransakcjeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InnePrawa_Transakcje_TransS_Id",
                        column: x => x.TransS_Id,
                        principalTable: "Transakcje",
                        principalColumn: "TransakcjeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlatnoscInnePrawa",
                columns: table => new
                {
                    PlatnoscInnePrawaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InnePrawaId = table.Column<int>(nullable: true),
                    Stawka = table.Column<double>(nullable: true),
                    Okres = table.Column<int>(nullable: true),
                    Wartosc = table.Column<double>(nullable: true),
                    Wysokosc = table.Column<double>(nullable: true),
                    rok1 = table.Column<int>(nullable: true),
                    rok2 = table.Column<int>(nullable: true),
                    rok3 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatnoscInnePrawa", x => x.PlatnoscInnePrawaId);
                    table.ForeignKey(
                        name: "FK_PlatnoscInnePrawa_InnePrawa_InnePrawaId",
                        column: x => x.InnePrawaId,
                        principalTable: "InnePrawa",
                        principalColumn: "InnePrawaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InnePrawa_RodzajInnegoPrawaSloId",
                table: "InnePrawa",
                column: "RodzajInnegoPrawaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_InnePrawa_TransK_Id",
                table: "InnePrawa",
                column: "TransK_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InnePrawa_TransS_Id",
                table: "InnePrawa",
                column: "TransS_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlatnoscInnePrawa_InnePrawaId",
                table: "PlatnoscInnePrawa",
                column: "InnePrawaId",
                unique: true,
                filter: "[InnePrawaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecyzjeAdministracyjne");

            migrationBuilder.DropTable(
                name: "PlatnoscInnePrawa");

            migrationBuilder.DropTable(
                name: "InnePrawa");

            migrationBuilder.DropTable(
                name: "RodzajInnegoPrawaSlo");
        }
    }
}
