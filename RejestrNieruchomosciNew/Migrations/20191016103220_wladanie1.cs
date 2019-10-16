using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class wladanie1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DzielnicaSlo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DzielnicaSlo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GminaSlo",
                columns: table => new
                {
                    GminaSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GminaSlo", x => x.GminaSloId);
                });

            migrationBuilder.CreateTable(
                name: "Wladanie",
                columns: table => new
                {
                    WladanieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: false),
                    PodmiodId = table.Column<int>(nullable: false),
                    FormaWladaniaId = table.Column<int>(nullable: true),
                    NazwaCzynnosciId = table.Column<int>(nullable: true),
                    RodzajDokumentuId = table.Column<int>(nullable: true),
                    PlatnoscUwId = table.Column<int>(nullable: true),
                    TytulDokumentu = table.Column<string>(nullable: true),
                    DataDokumentu = table.Column<DateTime>(nullable: true),
                    DataObowiazywaniaOd = table.Column<DateTime>(nullable: true),
                    DataObowiazywaniaDo = table.Column<DateTime>(nullable: true),
                    Udzial = table.Column<string>(nullable: true),
                    Stawka = table.Column<int>(nullable: true),
                    Okres = table.Column<int>(nullable: true),
                    Wartosc = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wladanie", x => x.WladanieId);
                });

            migrationBuilder.CreateTable(
                name: "Obreb",
                columns: table => new
                {
                    ObrebId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    GminaSloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obreb", x => x.ObrebId);
                    table.ForeignKey(
                        name: "FK_Obreb_GminaSlo_GminaSloId",
                        column: x => x.GminaSloId,
                        principalTable: "GminaSlo",
                        principalColumn: "GminaSloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormaWladaniaSlo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    WladanieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaWladaniaSlo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormaWladaniaSlo_Wladanie_WladanieId",
                        column: x => x.WladanieId,
                        principalTable: "Wladanie",
                        principalColumn: "WladanieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NazwaCzynnosciSlo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    WladanieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NazwaCzynnosciSlo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NazwaCzynnosciSlo_Wladanie_WladanieId",
                        column: x => x.WladanieId,
                        principalTable: "Wladanie",
                        principalColumn: "WladanieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlatnoscUw",
                columns: table => new
                {
                    PlatnoscUwId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Stawka = table.Column<double>(nullable: true),
                    Okres = table.Column<int>(nullable: true),
                    Wartosc = table.Column<double>(nullable: true),
                    WladanieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatnoscUw", x => x.PlatnoscUwId);
                    table.ForeignKey(
                        name: "FK_PlatnoscUw_Wladanie_WladanieId",
                        column: x => x.WladanieId,
                        principalTable: "Wladanie",
                        principalColumn: "WladanieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Podmiot",
                columns: table => new
                {
                    PodmiotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Kontakt = table.Column<string>(nullable: true),
                    TaxNumber = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    WladanieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podmiot", x => x.PodmiotId);
                    table.ForeignKey(
                        name: "FK_Podmiot_Wladanie_WladanieId",
                        column: x => x.WladanieId,
                        principalTable: "Wladanie",
                        principalColumn: "WladanieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RodzajDokumentuSlo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    WladanieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajDokumentuSlo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RodzajDokumentuSlo_Wladanie_WladanieId",
                        column: x => x.WladanieId,
                        principalTable: "Wladanie",
                        principalColumn: "WladanieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dzialka",
                columns: table => new
                {
                    DzialkaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numer = table.Column<string>(nullable: true),
                    Kwakt = table.Column<string>(nullable: true),
                    Kwzrob = table.Column<string>(nullable: true),
                    Pow = table.Column<decimal>(nullable: true),
                    ObrebId = table.Column<int>(nullable: false),
                    WladanieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzialka", x => x.DzialkaId);
                    table.ForeignKey(
                        name: "FK_Dzialka_Obreb_ObrebId",
                        column: x => x.ObrebId,
                        principalTable: "Obreb",
                        principalColumn: "ObrebId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dzialka_Wladanie_WladanieId",
                        column: x => x.WladanieId,
                        principalTable: "Wladanie",
                        principalColumn: "WladanieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InnePrawa",
                columns: table => new
                {
                    InnePrawaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: false),
                    PodmiotId = table.Column<int>(nullable: false),
                    PrzedstawicielId = table.Column<int>(nullable: true),
                    NazwaCzynnosciNabId = table.Column<int>(nullable: true),
                    RodzajDokumentuNabId = table.Column<int>(nullable: true),
                    NrDokumentuNab = table.Column<string>(nullable: true),
                    DataDokumentuNab = table.Column<DateTime>(nullable: true),
                    TytulDokumentuNab = table.Column<string>(nullable: true),
                    DataWpisuKwnab = table.Column<DateTime>(nullable: true),
                    DataObowiazywaniaOd = table.Column<DateTime>(nullable: true),
                    DataObowiazywaniaDo = table.Column<DateTime>(nullable: true),
                    DoPrzekazania = table.Column<DateTime>(nullable: true),
                    DoZwrotnegoPrzekazania = table.Column<DateTime>(nullable: true),
                    Stawka = table.Column<int>(nullable: true),
                    Okres = table.Column<int>(nullable: true),
                    Wartosc = table.Column<decimal>(nullable: true),
                    WarunkiRealizacji = table.Column<string>(nullable: true),
                    DecyzjaNr = table.Column<string>(nullable: true),
                    DecyzjaData = table.Column<DateTime>(nullable: true),
                    DecyzjaOrganId = table.Column<int>(nullable: true),
                    DecyzjaPrzedmiot = table.Column<string>(nullable: true),
                    NazwaCzynnosciZbId = table.Column<int>(nullable: true),
                    RodzajDokumentuZbId = table.Column<int>(nullable: true),
                    NrDokumentuZb = table.Column<string>(nullable: true),
                    DataDokumentuZb = table.Column<DateTime>(nullable: true),
                    TytulDokumentuZb = table.Column<string>(nullable: true),
                    DataWpisuKwzb = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnePrawa", x => x.InnePrawaId);
                    table.ForeignKey(
                        name: "FK_InnePrawa_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_ObrebId",
                table: "Dzialka",
                column: "ObrebId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_WladanieId",
                table: "Dzialka",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_Numer_ObrebId",
                table: "Dzialka",
                columns: new[] { "Numer", "ObrebId" },
                unique: true,
                filter: "[Numer] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FormaWladaniaSlo_WladanieId",
                table: "FormaWladaniaSlo",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_InnePrawa_DzialkaId",
                table: "InnePrawa",
                column: "DzialkaId");

            migrationBuilder.CreateIndex(
                name: "IX_NazwaCzynnosciSlo_WladanieId",
                table: "NazwaCzynnosciSlo",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_Obreb_GminaSloId",
                table: "Obreb",
                column: "GminaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatnoscUw_WladanieId",
                table: "PlatnoscUw",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_Podmiot_WladanieId",
                table: "Podmiot",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_RodzajDokumentuSlo_WladanieId",
                table: "RodzajDokumentuSlo",
                column: "WladanieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DzielnicaSlo");

            migrationBuilder.DropTable(
                name: "FormaWladaniaSlo");

            migrationBuilder.DropTable(
                name: "InnePrawa");

            migrationBuilder.DropTable(
                name: "NazwaCzynnosciSlo");

            migrationBuilder.DropTable(
                name: "PlatnoscUw");

            migrationBuilder.DropTable(
                name: "Podmiot");

            migrationBuilder.DropTable(
                name: "RodzajDokumentuSlo");

            migrationBuilder.DropTable(
                name: "Dzialka");

            migrationBuilder.DropTable(
                name: "Obreb");

            migrationBuilder.DropTable(
                name: "Wladanie");

            migrationBuilder.DropTable(
                name: "GminaSlo");
        }
    }
}
