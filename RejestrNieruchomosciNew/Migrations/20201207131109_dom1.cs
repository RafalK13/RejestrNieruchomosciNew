using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budynek",
                columns: table => new
                {
                    BudynekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    powBezPiwnic = table.Column<int>(nullable: false),
                    powZPiwnic = table.Column<int>(nullable: false),
                    powCalk = table.Column<int>(nullable: false),
                    powZabud = table.Column<int>(nullable: false),
                    kubatura = table.Column<int>(nullable: false),
                    iloscKond = table.Column<int>(nullable: false),
                    numerEwid = table.Column<string>(nullable: true),
                    wpisRejZab = table.Column<bool>(nullable: false),
                    prad = table.Column<bool>(nullable: false),
                    woda = table.Column<bool>(nullable: false),
                    kanSan = table.Column<bool>(nullable: false),
                    kanLok = table.Column<bool>(nullable: false),
                    kanDeszcz = table.Column<bool>(nullable: false),
                    tel = table.Column<bool>(nullable: false),
                    co = table.Column<bool>(nullable: false),
                    gaz = table.Column<bool>(nullable: false),
                    internet = table.Column<bool>(nullable: false),
                    tv = table.Column<bool>(nullable: false),
                    opisKonstr = table.Column<string>(nullable: true),
                    stanTech = table.Column<string>(nullable: true),
                    jednorodzinny = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budynek", x => x.BudynekId);
                });

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
                name: "KonserwPrzyrodySlo",
                columns: table => new
                {
                    KonserwPrzyrodySloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonserwPrzyrodySlo", x => x.KonserwPrzyrodySloId);
                });

            migrationBuilder.CreateTable(
                name: "KonserwZabytkowSlo",
                columns: table => new
                {
                    KonserwZabytkowSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonserwZabytkowSlo", x => x.KonserwZabytkowSloId);
                });

            migrationBuilder.CreateTable(
                name: "MiejscowoscSlo",
                columns: table => new
                {
                    MiejscowoscSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GminaSloId = table.Column<int>(nullable: false),
                    MiejscowoscUlice = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiejscowoscSlo", x => x.MiejscowoscSloId);
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
                name: "PrzedstawicielSlo",
                columns: table => new
                {
                    PrzedstawicielSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrzedstawicielSlo", x => x.PrzedstawicielSloId);
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
                    UlicaSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MiejscowoscUlice = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UliceSlo", x => x.UlicaSloId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
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
                name: "Lokal",
                columns: table => new
                {
                    LokalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numer = table.Column<string>(nullable: true),
                    pow = table.Column<double>(nullable: true),
                    powPomPrzyn = table.Column<double>(nullable: true),
                    opis = table.Column<string>(nullable: true),
                    kondygnacja = table.Column<string>(nullable: true),
                    KWlok = table.Column<string>(nullable: true),
                    NajemcaId = table.Column<int>(nullable: false),
                    BudynekId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokal", x => x.LokalId);
                    table.ForeignKey(
                        name: "FK_Lokal_Budynek_BudynekId",
                        column: x => x.BudynekId,
                        principalTable: "Budynek",
                        principalColumn: "BudynekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obreb",
                columns: table => new
                {
                    ObrebId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    Numer = table.Column<string>(nullable: true),
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
                name: "ZagospStatus",
                columns: table => new
                {
                    ZagospStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZagospStatusSloId = table.Column<int>(nullable: false),
                    ZagospFunkcjaSloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZagospStatus", x => x.ZagospStatusId);
                    table.ForeignKey(
                        name: "FK_ZagospStatus_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                        column: x => x.ZagospFunkcjaSloId,
                        principalTable: "ZagospFunkcjaSlo",
                        principalColumn: "ZagospFunkcjaSloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZagospStatus_ZagospStatusSlo_ZagospStatusSloId",
                        column: x => x.ZagospStatusSloId,
                        principalTable: "ZagospStatusSlo",
                        principalColumn: "ZagospStatusSloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lokal_Podmiot",
                columns: table => new
                {
                    Lokal_PodmiotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LokalId = table.Column<int>(nullable: false),
                    PodmiotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokal_Podmiot", x => x.Lokal_PodmiotId);
                    table.ForeignKey(
                        name: "FK_Lokal_Podmiot_Lokal_LokalId",
                        column: x => x.LokalId,
                        principalTable: "Lokal",
                        principalColumn: "LokalId",
                        onDelete: ReferentialAction.Cascade);
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
                    KonserwZabytkowSloId = table.Column<int>(nullable: true),
                    KonserwPrzyrodySloId = table.Column<int>(nullable: true),
                    ObrebId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzialka", x => x.DzialkaId);
                    table.ForeignKey(
                        name: "FK_Dzialka_KonserwPrzyrodySlo_KonserwPrzyrodySloId",
                        column: x => x.KonserwPrzyrodySloId,
                        principalTable: "KonserwPrzyrodySlo",
                        principalColumn: "KonserwPrzyrodySloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dzialka_KonserwZabytkowSlo_KonserwZabytkowSloId",
                        column: x => x.KonserwZabytkowSloId,
                        principalTable: "KonserwZabytkowSlo",
                        principalColumn: "KonserwZabytkowSloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dzialka_Obreb_ObrebId",
                        column: x => x.ObrebId,
                        principalTable: "Obreb",
                        principalColumn: "ObrebId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    AdresId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numer = table.Column<string>(nullable: true),
                    MiejscowoscSloId = table.Column<int>(nullable: false),
                    UlicaSloId = table.Column<int>(nullable: true),
                    DzialkaId = table.Column<int>(nullable: true),
                    BudynekId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.AdresId);
                    table.ForeignKey(
                        name: "FK_Adres_Budynek_BudynekId",
                        column: x => x.BudynekId,
                        principalTable: "Budynek",
                        principalColumn: "BudynekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adres_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adres_MiejscowoscSlo_MiejscowoscSloId",
                        column: x => x.MiejscowoscSloId,
                        principalTable: "MiejscowoscSlo",
                        principalColumn: "MiejscowoscSloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adres_UliceSlo_UlicaSloId",
                        column: x => x.UlicaSloId,
                        principalTable: "UliceSlo",
                        principalColumn: "UlicaSloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dzialka_Budynek",
                columns: table => new
                {
                    DzialkaId = table.Column<int>(nullable: false),
                    BudynekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzialka_Budynek", x => new { x.DzialkaId, x.BudynekId });
                    table.ForeignKey(
                        name: "FK_Dzialka_Budynek_Budynek_BudynekId",
                        column: x => x.BudynekId,
                        principalTable: "Budynek",
                        principalColumn: "BudynekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dzialka_Budynek_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
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
                    DzialkaId = table.Column<int>(nullable: true),
                    ZagospStatusId = table.Column<int>(nullable: true),
                    istObiektySloId = table.Column<int>(nullable: true),
                    zadInwestSloId = table.Column<int>(nullable: true),
                    PlanowaneZagosp = table.Column<string>(nullable: true),
                    DodatkoweZagosp = table.Column<string>(nullable: true),
                    DoWylaczenia = table.Column<string>(nullable: true),
                    WylaczenieProt = table.Column<string>(nullable: true),
                    WylacznieInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zagosp", x => x.ZagospId);
                    table.ForeignKey(
                        name: "FK_Zagosp_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zagosp_ZagospStatus_ZagospStatusId",
                        column: x => x.ZagospStatusId,
                        principalTable: "ZagospStatus",
                        principalColumn: "ZagospStatusId",
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
                table: "KonserwPrzyrodySlo",
                columns: new[] { "KonserwPrzyrodySloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "Nie" },
                    { 3, "Tak" }
                });

            migrationBuilder.InsertData(
                table: "KonserwZabytkowSlo",
                columns: new[] { "KonserwZabytkowSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "rejestr zabytków" },
                    { 3, "Gminna Ewidencja Zabytków" },
                    { 4, "Wojewódzka Ewidencja Zabytków" },
                    { 5, "MPZP" }
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
                table: "PrzedstawicielSlo",
                columns: new[] { "PrzedstawicielSloId", "Nazwa" },
                values: new object[,]
                {
                    { 4, "GIWK TS" },
                    { 3, "GIWK TE" },
                    { 2, "GIWK EE" },
                    { 1, "-" },
                    { 6, "inny" },
                    { 5, "SNG" }
                });

            migrationBuilder.InsertData(
                table: "RodzajDokumentuSlo",
                columns: new[] { "RodzajDokumentuSloId", "Nazwa" },
                values: new object[,]
                {
                    { 2, "Akt notarialny" },
                    { 3, "Postanowienie sądu" },
                    { 1, "-" }
                });

            migrationBuilder.InsertData(
                table: "RodzajInnegoPrawaSlo",
                columns: new[] { "RodzajInnegoPrawaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "dzierżawa" },
                    { 3, "najem" },
                    { 5, "służebność" },
                    { 6, "czasowe zajęcie" },
                    { 7, "bezumowne" },
                    { 4, "użyczenie" }
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
                table: "User",
                columns: new[] { "UserId", "admin", "name" },
                values: new object[,]
                {
                    { 4, true, "mkomorowski" },
                    { 3, true, "emegger2" },
                    { 1, true, "rkarczewski" },
                    { 2, true, "emegger" }
                });

            migrationBuilder.InsertData(
                table: "UzytkiSlo",
                columns: new[] { "UzytkiSloId", "Nazwa" },
                values: new object[,]
                {
                    { 23, "E-Ws" },
                    { 24, "E-Wp" },
                    { 25, "E-Ls" },
                    { 26, "E-Lz" },
                    { 27, "E-N" },
                    { 28, "E-Ps" },
                    { 29, "E-R" },
                    { 30, "E-Ł" },
                    { 31, "E-Lzr" },
                    { 32, "E-W" },
                    { 33, "Wm" },
                    { 34, "Wp" },
                    { 35, "Ws" },
                    { 36, "Tr" },
                    { 22, "Tp" },
                    { 21, "Ti" },
                    { 15, "Bi" },
                    { 19, "dr" },
                    { 1, "-" },
                    { 2, "R" },
                    { 20, "Tk" },
                    { 4, "Ł" },
                    { 5, "Ps" },
                    { 6, "Br" },
                    { 7, "Wsr" },
                    { 9, "Lzr" },
                    { 3, "S" },
                    { 11, "Ls" },
                    { 18, "K" },
                    { 10, "N" },
                    { 17, "Bz" },
                    { 8, "W" },
                    { 14, "Ba" },
                    { 13, "B" },
                    { 12, "Lz" },
                    { 16, "Bp" }
                });

            migrationBuilder.InsertData(
                table: "ZagospFunkcjaSlo",
                columns: new[] { "ZagospFunkcjaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "wodociągowa" },
                    { 2, "kanlizacyjna" },
                    { 3, "energetyczna" },
                    { 5, "społeczna" },
                    { 6, "użytkowa" },
                    { 7, "finansowa" },
                    { 8, "mieszana" },
                    { 4, "mieszana" }
                });

            migrationBuilder.InsertData(
                table: "ZagospStatusSlo",
                columns: new[] { "ZagospStatusSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Wod/Kan/Energ" },
                    { 2, "Komercyjna" }
                });

            migrationBuilder.InsertData(
                table: "ZagospStatus",
                columns: new[] { "ZagospStatusId", "ZagospFunkcjaSloId", "ZagospStatusSloId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 2 },
                    { 6, 6, 2 },
                    { 7, 7, 2 },
                    { 8, 8, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_BudynekId",
                table: "Adres",
                column: "BudynekId",
                unique: true,
                filter: "[BudynekId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_DzialkaId",
                table: "Adres",
                column: "DzialkaId",
                unique: true,
                filter: "[DzialkaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_MiejscowoscSloId",
                table: "Adres",
                column: "MiejscowoscSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_UlicaSloId",
                table: "Adres",
                column: "UlicaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_KonserwPrzyrodySloId",
                table: "Dzialka",
                column: "KonserwPrzyrodySloId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_KonserwZabytkowSloId",
                table: "Dzialka",
                column: "KonserwZabytkowSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_ObrebId",
                table: "Dzialka",
                column: "ObrebId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_Numer_ObrebId",
                table: "Dzialka",
                columns: new[] { "Numer", "ObrebId" },
                unique: true,
                filter: "[Numer] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_Budynek_BudynekId",
                table: "Dzialka_Budynek",
                column: "BudynekId");

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
                name: "IX_Lokal_BudynekId",
                table: "Lokal",
                column: "BudynekId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokal_Podmiot_LokalId",
                table: "Lokal_Podmiot",
                column: "LokalId");

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
                column: "DzialkaId",
                unique: true,
                filter: "[DzialkaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Zagosp_ZagospStatusId",
                table: "Zagosp",
                column: "ZagospStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ZagospStatus_ZagospFunkcjaSloId",
                table: "ZagospStatus",
                column: "ZagospFunkcjaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_ZagospStatus_ZagospStatusSloId",
                table: "ZagospStatus",
                column: "ZagospStatusSloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Dzialka_Budynek");

            migrationBuilder.DropTable(
                name: "Lokal_Podmiot");

            migrationBuilder.DropTable(
                name: "PlatnoscInnePrawa");

            migrationBuilder.DropTable(
                name: "PlatnoscUW");

            migrationBuilder.DropTable(
                name: "PrzedstawicielSlo");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Uzytki");

            migrationBuilder.DropTable(
                name: "Wladanie");

            migrationBuilder.DropTable(
                name: "Zagosp");

            migrationBuilder.DropTable(
                name: "MiejscowoscSlo");

            migrationBuilder.DropTable(
                name: "UliceSlo");

            migrationBuilder.DropTable(
                name: "Lokal");

            migrationBuilder.DropTable(
                name: "InnePrawa");

            migrationBuilder.DropTable(
                name: "UzytkiSlo");

            migrationBuilder.DropTable(
                name: "FormaWladaniaSlo");

            migrationBuilder.DropTable(
                name: "ZagospStatus");

            migrationBuilder.DropTable(
                name: "Budynek");

            migrationBuilder.DropTable(
                name: "DecyzjeAdministracyjne");

            migrationBuilder.DropTable(
                name: "Dzialka");

            migrationBuilder.DropTable(
                name: "RodzajInnegoPrawaSlo");

            migrationBuilder.DropTable(
                name: "Transakcje");

            migrationBuilder.DropTable(
                name: "ZagospFunkcjaSlo");

            migrationBuilder.DropTable(
                name: "ZagospStatusSlo");

            migrationBuilder.DropTable(
                name: "KonserwPrzyrodySlo");

            migrationBuilder.DropTable(
                name: "KonserwZabytkowSlo");

            migrationBuilder.DropTable(
                name: "Obreb");

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
