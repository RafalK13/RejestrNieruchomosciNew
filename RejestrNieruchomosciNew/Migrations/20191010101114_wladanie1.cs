using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class wladanie1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GminaSlo",
                keyColumn: "GminaSloId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GminaSlo",
                keyColumn: "GminaSloId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GminaSlo",
                keyColumn: "GminaSloId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Obreb",
                keyColumn: "ObrebId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "GminaSlo",
                keyColumn: "GminaSloId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GminaSlo",
                keyColumn: "GminaSloId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GminaSlo",
                keyColumn: "GminaSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GminaSlo",
                keyColumn: "GminaSloId",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "WladanieId",
                table: "Dzialka",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Wladanie",
                columns: table => new
                {
                    WladanieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: false),
                    PodmiodId = table.Column<int>(nullable: true),
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
                name: "MK_REJNIER_PERSONS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    WladanieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MK_REJNIER_PERSONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MK_REJNIER_PERSONS_Wladanie_WladanieId",
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Stawka = table.Column<double>(nullable: true),
                    Okres = table.Column<int>(nullable: true),
                    Wartosc = table.Column<double>(nullable: true),
                    WladanieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatnoscUw", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatnoscUw_Wladanie_WladanieId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_WladanieId",
                table: "Dzialka",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaWladaniaSlo_WladanieId",
                table: "FormaWladaniaSlo",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_MK_REJNIER_PERSONS_WladanieId",
                table: "MK_REJNIER_PERSONS",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_NazwaCzynnosciSlo_WladanieId",
                table: "NazwaCzynnosciSlo",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatnoscUw_WladanieId",
                table: "PlatnoscUw",
                column: "WladanieId");

            migrationBuilder.CreateIndex(
                name: "IX_RodzajDokumentuSlo_WladanieId",
                table: "RodzajDokumentuSlo",
                column: "WladanieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dzialka_Wladanie_WladanieId",
                table: "Dzialka",
                column: "WladanieId",
                principalTable: "Wladanie",
                principalColumn: "WladanieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dzialka_Wladanie_WladanieId",
                table: "Dzialka");

            migrationBuilder.DropTable(
                name: "FormaWladaniaSlo");

            migrationBuilder.DropTable(
                name: "MK_REJNIER_PERSONS");

            migrationBuilder.DropTable(
                name: "NazwaCzynnosciSlo");

            migrationBuilder.DropTable(
                name: "PlatnoscUw");

            migrationBuilder.DropTable(
                name: "RodzajDokumentuSlo");

            migrationBuilder.DropTable(
                name: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Dzialka_WladanieId",
                table: "Dzialka");

            migrationBuilder.DropColumn(
                name: "WladanieId",
                table: "Dzialka");

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
                table: "Obreb",
                columns: new[] { "ObrebId", "GminaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, 10, "010" },
                    { 23, 12, "030" },
                    { 22, 12, "020" },
                    { 21, 12, "010" },
                    { 20, 11, "070" },
                    { 19, 11, "060" },
                    { 18, 11, "050" },
                    { 17, 11, "040" },
                    { 16, 11, "030" },
                    { 15, 11, "020" },
                    { 14, 11, "010" },
                    { 24, 13, "040" },
                    { 13, 10, "130" },
                    { 11, 10, "110" },
                    { 10, 10, "100" },
                    { 9, 10, "090" },
                    { 8, 10, "080" },
                    { 7, 10, "070" },
                    { 6, 10, "060" },
                    { 5, 10, "050" },
                    { 4, 10, "040" },
                    { 3, 10, "030" },
                    { 2, 10, "020" },
                    { 12, 10, "120" },
                    { 25, 13, "050" }
                });
        }
    }
}
