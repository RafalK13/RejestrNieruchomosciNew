using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "NazwaCzynnosciSlo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NazwaCzynnosciSlo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatnoscUw",
                columns: table => new
                {
                    PlatnoscUWId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: true),
                    Stawka = table.Column<double>(nullable: true),
                    Okres = table.Column<int>(nullable: true),
                    Wartosc = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatnoscUw", x => x.PlatnoscUWId);
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
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podmiot", x => x.PodmiotId);
                });

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
                name: "Dzialka",
                columns: table => new
                {
                    DzialkaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numer = table.Column<string>(nullable: true),
                    Kwakt = table.Column<string>(nullable: true),
                    Kwzrob = table.Column<string>(nullable: true),
                    Pow = table.Column<decimal>(nullable: true),
                    ObrebId = table.Column<int>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Wladanie",
                columns: table => new
                {
                    WladanieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: true),
                    PodmiodId = table.Column<int>(nullable: true),
                    FormaWladaniaId = table.Column<int>(nullable: true),
                    Udzial = table.Column<string>(nullable: true),
                    NabycieId = table.Column<int>(nullable: true),
                    ZbycieId = table.Column<int>(nullable: true),
                    FormaWladaniaSloId = table.Column<int>(nullable: true),
                    NazwaCzynnosciSloId = table.Column<int>(nullable: true),
                    PlatnoscUWId = table.Column<int>(nullable: true),
                    PodmiotId = table.Column<int>(nullable: true),
                    RodzajDokumentuSloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wladanie", x => x.WladanieId);
                    table.ForeignKey(
                        name: "FK_Wladanie_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wladanie_FormaWladaniaSlo_FormaWladaniaSloId",
                        column: x => x.FormaWladaniaSloId,
                        principalTable: "FormaWladaniaSlo",
                        principalColumn: "FormaWladaniaSloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wladanie_NazwaCzynnosciSlo_NazwaCzynnosciSloId",
                        column: x => x.NazwaCzynnosciSloId,
                        principalTable: "NazwaCzynnosciSlo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wladanie_PlatnoscUw_PlatnoscUWId",
                        column: x => x.PlatnoscUWId,
                        principalTable: "PlatnoscUw",
                        principalColumn: "PlatnoscUWId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wladanie_Podmiot_PodmiotId",
                        column: x => x.PodmiotId,
                        principalTable: "Podmiot",
                        principalColumn: "PodmiotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wladanie_RodzajDokumentuSlo_RodzajDokumentuSloId",
                        column: x => x.RodzajDokumentuSloId,
                        principalTable: "RodzajDokumentuSlo",
                        principalColumn: "RodzajDokumentuSloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FormaWladaniaSlo",
                columns: new[] { "FormaWladaniaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Własność" },
                    { 2, "UW" }
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
                table: "RodzajCzynnosciSlo",
                columns: new[] { "RodzajCzynnosciSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Kupno" },
                    { 2, "Sprzedaż" }
                });

            migrationBuilder.InsertData(
                table: "RodzajDokScanSlo",
                columns: new[] { "RodzajDokScanSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Transakcje" },
                    { 2, "Nabycie Prawa" }
                });

            migrationBuilder.InsertData(
                table: "RodzajDokumentuSlo",
                columns: new[] { "RodzajDokumentuSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Akt notarialny" },
                    { 2, "Postanowienie sądu" }
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
                name: "IX_Obreb_GminaSloId",
                table: "Obreb",
                column: "GminaSloId");

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
                name: "IX_Wladanie_PlatnoscUWId",
                table: "Wladanie",
                column: "PlatnoscUWId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_PodmiotId",
                table: "Wladanie",
                column: "PodmiotId");

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_RodzajDokumentuSloId",
                table: "Wladanie",
                column: "RodzajDokumentuSloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RodzajCzynnosciSlo");

            migrationBuilder.DropTable(
                name: "RodzajDokScanSlo");

            migrationBuilder.DropTable(
                name: "Wladanie");

            migrationBuilder.DropTable(
                name: "Dzialka");

            migrationBuilder.DropTable(
                name: "FormaWladaniaSlo");

            migrationBuilder.DropTable(
                name: "NazwaCzynnosciSlo");

            migrationBuilder.DropTable(
                name: "PlatnoscUw");

            migrationBuilder.DropTable(
                name: "Podmiot");

            migrationBuilder.DropTable(
                name: "RodzajDokumentuSlo");

            migrationBuilder.DropTable(
                name: "Obreb");

            migrationBuilder.DropTable(
                name: "GminaSlo");
        }
    }
}
