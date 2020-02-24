using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca1 : Migration
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
                name: "FormaWladaniaSlo",
                columns: table => new
                {
                    FormaWladaniaSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaWladaniaSlo", x => x.FormaWladaniaSloId);
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
                name: "NadzorKonserwSlo",
                columns: table => new
                {
                    NadzorKonserwSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NadzorKonserwSlo", x => x.NadzorKonserwSloId);
                });

            migrationBuilder.CreateTable(
                name: "NazwaCzynnosciSlo",
                columns: table => new
                {
                    NazwaCzynnosciSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NazwaCzynnosciSlo", x => x.NazwaCzynnosciSloId);
                });

            migrationBuilder.CreateTable(
                name: "RodzajDokumentuSlo",
                columns: table => new
                {
                    RodzajDokumentuSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajDokumentuSlo", x => x.RodzajDokumentuSloId);
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

            migrationBuilder.CreateTable(
                name: "UliceSlo",
                columns: table => new
                {
                    UliceSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UliceSlo", x => x.UliceSloId);
                });

            migrationBuilder.CreateTable(
                name: "UzytkiSlo",
                columns: table => new
                {
                    UzytkiSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UzytkiSlo", x => x.UzytkiSloId);
                });

            migrationBuilder.CreateTable(
                name: "ZagospFunkcjaSlo",
                columns: table => new
                {
                    ZagospFunkcjaSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZagospFunkcjaSlo", x => x.ZagospFunkcjaSloId);
                });

            migrationBuilder.CreateTable(
                name: "ZagospStatusSlo",
                columns: table => new
                {
                    ZagospStatusSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZagospStatusSlo", x => x.ZagospStatusSloId);
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
                name: "Transakcje",
                columns: table => new
                {
                    TransakcjeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RodzajTransakcjiSloId = table.Column<int>(nullable: true),
                    NazwaCzynnosciSloId = table.Column<int>(nullable: true),
                    RodzajDokumentuSloId = table.Column<int>(nullable: true),
                    Numer = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: true),
                    Tytul = table.Column<string>(nullable: true),
                    Skan = table.Column<string>(nullable: true),
                    WpisDoKW = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcje", x => x.TransakcjeId);
                    table.ForeignKey(
                        name: "FK_Transakcje_NazwaCzynnosciSlo_NazwaCzynnosciSloId",
                        column: x => x.NazwaCzynnosciSloId,
                        principalTable: "NazwaCzynnosciSlo",
                        principalColumn: "NazwaCzynnosciSloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transakcje_RodzajDokumentuSlo_RodzajDokumentuSloId",
                        column: x => x.RodzajDokumentuSloId,
                        principalTable: "RodzajDokumentuSlo",
                        principalColumn: "RodzajDokumentuSloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transakcje_RodzajTransakcjiSlo_RodzajTransakcjiSloId",
                        column: x => x.RodzajTransakcjiSloId,
                        principalTable: "RodzajTransakcjiSlo",
                        principalColumn: "RodzajTransakcjiSloId",
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
                    Pow = table.Column<double>(nullable: true),
                    lokalizacja = table.Column<string>(nullable: true),
                    uzbrojenie = table.Column<string>(nullable: true),
                    ksztalt = table.Column<string>(nullable: true),
                    sasiedztwo = table.Column<string>(nullable: true),
                    dostDoDrogi = table.Column<string>(nullable: true),
                    rodzNaw = table.Column<string>(nullable: true),
                    UliceSloId = table.Column<int>(nullable: true),
                    NadzorKonserwSloId = table.Column<int>(nullable: true),
                    ObrebId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzialka", x => x.DzialkaId);
                    table.ForeignKey(
                        name: "FK_Dzialka_NadzorKonserwSlo_NadzorKonserwSloId",
                        column: x => x.NadzorKonserwSloId,
                        principalTable: "NadzorKonserwSlo",
                        principalColumn: "NadzorKonserwSloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dzialka_Obreb_ObrebId",
                        column: x => x.ObrebId,
                        principalTable: "Obreb",
                        principalColumn: "ObrebId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dzialka_UliceSlo_UliceSloId",
                        column: x => x.UliceSloId,
                        principalTable: "UliceSlo",
                        principalColumn: "UliceSloId",
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
                    TransK_Id = table.Column<int>(nullable: true),
                    TransS_Id = table.Column<int>(nullable: true),
                    DecyzjeAdministracyjneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnePrawa", x => x.InnePrawaId);
                    table.ForeignKey(
                        name: "FK_InnePrawa_DecyzjeAdministracyjne_DecyzjeAdministracyjneId",
                        column: x => x.DecyzjeAdministracyjneId,
                        principalTable: "DecyzjeAdministracyjne",
                        principalColumn: "DecyzjeAdministracyjneId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InnePrawa_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "PlatnoscUW",
                columns: table => new
                {
                    PlatnoscUWId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Stawka = table.Column<double>(nullable: true),
                    Okres = table.Column<int>(nullable: true),
                    Wartosc = table.Column<double>(nullable: true),
                    Wysokosc = table.Column<double>(nullable: true),
                    rok1 = table.Column<int>(nullable: true),
                    rok2 = table.Column<int>(nullable: true),
                    rok3 = table.Column<int>(nullable: true),
                    DzialkaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatnoscUW", x => x.PlatnoscUWId);
                    table.ForeignKey(
                        name: "FK_PlatnoscUW_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uzytki",
                columns: table => new
                {
                    UzytkiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: false),
                    UzytkiSloId = table.Column<int>(nullable: false),
                    Pow = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytki", x => x.UzytkiId);
                    table.ForeignKey(
                        name: "FK_Uzytki_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uzytki_UzytkiSlo_UzytkiSloId",
                        column: x => x.UzytkiSloId,
                        principalTable: "UzytkiSlo",
                        principalColumn: "UzytkiSloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wladanie",
                columns: table => new
                {
                    WladanieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: true),
                    PodmiotId = table.Column<int>(nullable: true),
                    FormaWladaniaSloId = table.Column<int>(nullable: true),
                    Udzial = table.Column<string>(nullable: true),
                    DataOdbOd = table.Column<DateTime>(nullable: true),
                    DataOdbDo = table.Column<DateTime>(nullable: true),
                    NrProtPrzejecia = table.Column<string>(nullable: true),
                    DataProtPrzej = table.Column<DateTime>(nullable: true),
                    Scan = table.Column<string>(nullable: true),
                    CelNabyciaId = table.Column<int>(nullable: true),
                    TransK_Id = table.Column<int>(nullable: true),
                    TransS_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wladanie", x => x.WladanieId);
                    table.ForeignKey(
                        name: "FK_Wladanie_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wladanie_FormaWladaniaSlo_FormaWladaniaSloId",
                        column: x => x.FormaWladaniaSloId,
                        principalTable: "FormaWladaniaSlo",
                        principalColumn: "FormaWladaniaSloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wladanie_Transakcje_TransK_Id",
                        column: x => x.TransK_Id,
                        principalTable: "Transakcje",
                        principalColumn: "TransakcjeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wladanie_Transakcje_TransS_Id",
                        column: x => x.TransS_Id,
                        principalTable: "Transakcje",
                        principalColumn: "TransakcjeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zagosp",
                columns: table => new
                {
                    ZagospId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true),
                    ZagospStatusSloId = table.Column<int>(nullable: true),
                    ZagospFunkcjaSloId = table.Column<int>(nullable: true),
                    istObiektySloId = table.Column<int>(nullable: true),
                    obiektyKomSloId = table.Column<int>(nullable: true),
                    zadInwestSloId = table.Column<int>(nullable: true),
                    celeKomSloId = table.Column<int>(nullable: true),
                    przedstSloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zagosp", x => x.ZagospId);
                    table.ForeignKey(
                        name: "FK_Zagosp_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zagosp_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                        column: x => x.ZagospFunkcjaSloId,
                        principalTable: "ZagospFunkcjaSlo",
                        principalColumn: "ZagospFunkcjaSloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zagosp_ZagospStatusSlo_ZagospStatusSloId",
                        column: x => x.ZagospStatusSloId,
                        principalTable: "ZagospStatusSlo",
                        principalColumn: "ZagospStatusSloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlatnoscInnePrawa",
                columns: table => new
                {
                    PlatnoscInnePrawaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Stawka = table.Column<double>(nullable: true),
                    Okres = table.Column<int>(nullable: true),
                    Wartosc = table.Column<double>(nullable: true),
                    Wysokosc = table.Column<double>(nullable: true),
                    rok1 = table.Column<int>(nullable: true),
                    rok2 = table.Column<int>(nullable: true),
                    rok3 = table.Column<int>(nullable: true),
                    InnePrawaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatnoscInnePrawa", x => x.PlatnoscInnePrawaId);
                    table.ForeignKey(
                        name: "FK_PlatnoscInnePrawa_InnePrawa_InnePrawaId",
                        column: x => x.InnePrawaId,
                        principalTable: "InnePrawa",
                        principalColumn: "InnePrawaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormaWladaniaSlo",
                columns: new[] { "FormaWladaniaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "Własność" },
                    { 3, "UW" }
                });

            migrationBuilder.InsertData(
                table: "GminaSlo",
                columns: new[] { "GminaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "miasto Gdańsk" },
                    { 2, "miasto Sopot" },
                    { 3, "miasto Pruszcz Gdański" },
                    { 4, "gmina Gdańsk" },
                    { 5, "gmina Pruszcz Gdański" },
                    { 6, "gmina Żukowo" },
                    { 7, "gmina Kolbudy" }
                });

            migrationBuilder.InsertData(
                table: "NadzorKonserwSlo",
                columns: new[] { "NadzorKonserwSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "Nie" },
                    { 3, "Tak" }
                });

            migrationBuilder.InsertData(
                table: "NazwaCzynnosciSlo",
                columns: new[] { "NazwaCzynnosciSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "Zakup" },
                    { 3, "Aport" }
                });

            migrationBuilder.InsertData(
                table: "RodzajDokumentuSlo",
                columns: new[] { "RodzajDokumentuSloId", "Nazwa" },
                values: new object[,]
                {
                    { 3, "Postanowienie sądu" },
                    { 2, "Akt notarialny" },
                    { 1, "-" }
                });

            migrationBuilder.InsertData(
                table: "RodzajInnegoPrawaSlo",
                columns: new[] { "RodzajInnegoPrawaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 7, "bezumowne" },
                    { 6, "czasowe zajęcie" },
                    { 1, "-" },
                    { 4, "użyczenie" },
                    { 3, "najem" },
                    { 2, "dzierżawa" },
                    { 5, "służebność" }
                });

            migrationBuilder.InsertData(
                table: "RodzajTransakcjiSlo",
                columns: new[] { "RodzajTransakcjiSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "Kupno" },
                    { 3, "Sprzedaż" }
                });

            migrationBuilder.InsertData(
                table: "UzytkiSlo",
                columns: new[] { "UzytkiSloId", "Nazwa" },
                values: new object[,]
                {
                    { 22, "Tp" },
                    { 23, "E-Ws" },
                    { 24, "E-Wp" },
                    { 25, "E-Ls" },
                    { 26, "E-Lz" },
                    { 27, "E-N" },
                    { 30, "E-Ł" },
                    { 29, "E-R" },
                    { 31, "E-Lzr" },
                    { 32, "E-W" },
                    { 21, "Ti" },
                    { 34, "Wp" },
                    { 35, "Ws" },
                    { 36, "Tr" },
                    { 28, "E-Ps" },
                    { 33, "Wm" },
                    { 20, "Tk" },
                    { 18, "K" },
                    { 1, "-" },
                    { 2, "R" },
                    { 19, "dr" },
                    { 4, "Ł" },
                    { 5, "Ps" },
                    { 6, "Br" },
                    { 7, "Wsr" },
                    { 8, "W" },
                    { 3, "S" },
                    { 10, "N" },
                    { 17, "Bz" },
                    { 9, "Lzr" },
                    { 16, "Bp" },
                    { 12, "Lz" },
                    { 14, "Ba" },
                    { 13, "B" },
                    { 11, "Ls" },
                    { 15, "Bi" }
                });

            migrationBuilder.InsertData(
                table: "ZagospFunkcjaSlo",
                columns: new[] { "ZagospFunkcjaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "społeczna" },
                    { 3, "użytkowa" },
                    { 5, "mieszana" },
                    { 4, "finansowa" }
                });

            migrationBuilder.InsertData(
                table: "ZagospStatusSlo",
                columns: new[] { "ZagospStatusSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "wodociągowa" },
                    { 3, "sanitarna" },
                    { 4, "komercyjna" },
                    { 5, "mieszana" }
                });

            migrationBuilder.InsertData(
                table: "Obreb",
                columns: new[] { "ObrebId", "GminaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, 1, "010" },
                    { 23, 4, "030" },
                    { 22, 3, "020" },
                    { 21, 3, "010" },
                    { 20, 2, "070" },
                    { 19, 2, "060" },
                    { 18, 2, "050" },
                    { 17, 2, "040" },
                    { 16, 2, "030" },
                    { 15, 2, "020" },
                    { 14, 2, "010" },
                    { 24, 4, "040" },
                    { 13, 1, "130" },
                    { 11, 1, "110" },
                    { 10, 1, "100" },
                    { 9, 1, "090" },
                    { 8, 1, "080" },
                    { 7, 1, "070" },
                    { 6, 1, "060" },
                    { 5, 1, "050" },
                    { 4, 1, "040" },
                    { 3, 1, "030" },
                    { 2, 1, "020" },
                    { 12, 1, "120" },
                    { 25, 4, "050" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_NadzorKonserwSloId",
                table: "Dzialka",
                column: "NadzorKonserwSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_ObrebId",
                table: "Dzialka",
                column: "ObrebId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_UliceSloId",
                table: "Dzialka",
                column: "UliceSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_Numer_ObrebId",
                table: "Dzialka",
                columns: new[] { "Numer", "ObrebId" },
                unique: true,
                filter: "[Numer] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InnePrawa_DecyzjeAdministracyjneId",
                table: "InnePrawa",
                column: "DecyzjeAdministracyjneId");

            migrationBuilder.CreateIndex(
                name: "IX_InnePrawa_DzialkaId",
                table: "InnePrawa",
                column: "DzialkaId");

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
                name: "IX_Obreb_GminaSloId",
                table: "Obreb",
                column: "GminaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatnoscInnePrawa_InnePrawaId",
                table: "PlatnoscInnePrawa",
                column: "InnePrawaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatnoscUW_DzialkaId",
                table: "PlatnoscUW",
                column: "DzialkaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transakcje_NazwaCzynnosciSloId",
                table: "Transakcje",
                column: "NazwaCzynnosciSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcje_RodzajDokumentuSloId",
                table: "Transakcje",
                column: "RodzajDokumentuSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcje_RodzajTransakcjiSloId",
                table: "Transakcje",
                column: "RodzajTransakcjiSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytki_DzialkaId",
                table: "Uzytki",
                column: "DzialkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytki_UzytkiSloId",
                table: "Uzytki",
                column: "UzytkiSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie",
                column: "DzialkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_FormaWladaniaSloId",
                table: "Wladanie",
                column: "FormaWladaniaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_TransK_Id",
                table: "Wladanie",
                column: "TransK_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_TransS_Id",
                table: "Wladanie",
                column: "TransS_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zagosp_DzialkaId",
                table: "Zagosp",
                column: "DzialkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zagosp_ZagospFunkcjaSloId",
                table: "Zagosp",
                column: "ZagospFunkcjaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Zagosp_ZagospStatusSloId",
                table: "Zagosp",
                column: "ZagospStatusSloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatnoscInnePrawa");

            migrationBuilder.DropTable(
                name: "PlatnoscUW");

            migrationBuilder.DropTable(
                name: "Uzytki");

            migrationBuilder.DropTable(
                name: "Wladanie");

            migrationBuilder.DropTable(
                name: "Zagosp");

            migrationBuilder.DropTable(
                name: "InnePrawa");

            migrationBuilder.DropTable(
                name: "UzytkiSlo");

            migrationBuilder.DropTable(
                name: "FormaWladaniaSlo");

            migrationBuilder.DropTable(
                name: "ZagospFunkcjaSlo");

            migrationBuilder.DropTable(
                name: "ZagospStatusSlo");

            migrationBuilder.DropTable(
                name: "DecyzjeAdministracyjne");

            migrationBuilder.DropTable(
                name: "Dzialka");

            migrationBuilder.DropTable(
                name: "RodzajInnegoPrawaSlo");

            migrationBuilder.DropTable(
                name: "Transakcje");

            migrationBuilder.DropTable(
                name: "NadzorKonserwSlo");

            migrationBuilder.DropTable(
                name: "Obreb");

            migrationBuilder.DropTable(
                name: "UliceSlo");

            migrationBuilder.DropTable(
                name: "NazwaCzynnosciSlo");

            migrationBuilder.DropTable(
                name: "RodzajDokumentuSlo");

            migrationBuilder.DropTable(
                name: "RodzajTransakcjiSlo");

            migrationBuilder.DropTable(
                name: "GminaSlo");
        }
    }
}
