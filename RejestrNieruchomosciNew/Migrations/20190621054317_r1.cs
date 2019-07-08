using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class r1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Obreb",
                columns: table => new
                {
                    ObrebId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    DzialkaId = table.Column<int>(nullable: true),
                    GminaSloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obreb", x => x.ObrebId);
                    table.ForeignKey(
                        name: "FK_Obreb_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obreb_GminaSlo_GminaSloId",
                        column: x => x.GminaSloId,
                        principalTable: "GminaSlo",
                        principalColumn: "GminaSloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dzialka",
                columns: new[] { "DzialkaId", "Kwakt", "Kwzrob", "Numer", "ObrebId", "Pow" },
                values: new object[,]
                {
                    { 1, null, "5454", "1", 0, 1200m },
                    { 52, "GD1G/13005/5", "GD1G/908342/5", "52", 0, 13m },
                    { 51, "GD1G/13005/5", "GD1G/908342/5", "51", 0, 13m },
                    { 50, "GD1G/955/13", "GD1G/908342/5", "50", 0, 13m },
                    { 49, "GD1G/955/13", "GD1G/900087/3", "49", 0, 13m },
                    { 48, "GD1G/955/13", "GD1G/900087/3", "48", 0, 249m },
                    { 47, "GD1G/955/13", "GD1G/900087/3", "47", 0, 249m },
                    { 53, "GD1G/13005/5", "GD1G/908342/5", "53", 0, 13m },
                    { 46, "GD1G/955/13", "GD1G/900087/3", "46", 0, 249m },
                    { 44, "GD1G/955/6", "GD1G/900087/3", "44", 0, 249m },
                    { 43, "GD1G/955/6", "GD1G/900087/3", "43", 0, 249m },
                    { 42, "GD1G/955/6", "GD1G/900087/3", "42", 0, 249m },
                    { 41, "GD1G/955/6", "GD1G/900087/3", "41", 0, 249m },
                    { 40, "GD1G/955/6", "GD1G/900087/3", "40", 0, 149m },
                    { 38, "GD1G/955/6", "GD1G/900087/3", "38", 0, 149m },
                    { 45, "GD1G/955/13", "GD1G/900087/3", "45", 0, 249m },
                    { 37, "GD1G/9955/6", "GD1G/100087/2", "37", 0, 149m },
                    { 54, "GD1G/113005/1", "GD1G/908342/5", "54", 0, 13m },
                    { 56, "GD1G/113005/1", "GD1G/908342/5", "56", 0, 89m },
                    { 70, "GD1G/0005/13", null, "70", 0, null },
                    { 69, "GD1G/0005/13", "GD1G/988842/13", "69", 0, 18m },
                    { 68, "GD1G/0005/13", "GD1G/988842/13", "68", 0, 18m },
                    { 67, "GD1G/0005/13", "GD1G/988842/13", "67", 0, 18m },
                    { 66, "GD1G/0005/13", "GD1G/988842/13", "66", 0, 18m },
                    { 65, "GD1G/0005/13", "GD1G/988842/13", "65", 0, 89m },
                    { 55, "GD1G/113005/1", "GD1G/908342/5", "55", 0, 13m },
                    { 64, "GD1G/0000955/13", "GD1G/988842/13", "64", 0, 89m },
                    { 62, "GD1G/0000955/13", "GD1G/908342/5", "62", 0, 89m },
                    { 61, "GD1G/0000955/13", "GD1G/908342/5", "61", 0, 89m },
                    { 60, "GD1G/0000955/13", "GD1G/908342/5", "60", 0, 89m },
                    { 59, "GD1G/0000955/13", "GD1G/908342/5", "59", 0, 89m },
                    { 58, "GD1G/113005/1", "GD1G/908342/5", "58", 0, 89m },
                    { 57, "GD1G/113005/1", "GD1G/908342/5", "57", 0, 89m },
                    { 63, "GD1G/0000955/13", "GD1G/908342/5", "63", 0, 89m },
                    { 36, "GD1G/9955/6", "GD1G/100087/2", "36", 0, 149m },
                    { 39, "GD1G/955/6", "GD1G/900087/3", "39", 0, 149m },
                    { 34, "GD1G/9955/6", "GD1G/100087/2", "34", 0, 149m },
                    { 35, "GD1G/9955/6", "GD1G/100087/2", "35", 0, 149m },
                    { 14, "GD1G/15225/1", "GD1G/00045487/1", "14", 0, 859m },
                    { 13, "GD1G/15225/1", null, "13", 0, 859m },
                    { 12, "GD1G/15225/1", null, "12", 0, 859m },
                    { 11, "GD1G/13005/5", null, "11", 0, 1052m },
                    { 10, "GD1G/13005/5", null, "10", 0, 10m },
                    { 16, "GD1G/15225/1", "GD1G/00045487/1", "16", 0, 859m },
                    { 9, "GD1G/13005/5", null, "9", 0, 10m },
                    { 7, "GD1G/13005/5", null, "7", 0, 10m },
                    { 6, "GD1G/13005/5", null, "6", 0, 400m },
                    { 5, "GD1G/13005/5", null, "5", 0, 400m },
                    { 4, "GD1G/13005/5", null, "4", 0, 1000m },
                    { 3, null, "5822", "3", 0, 1000m },
                    { 2, null, null, "2", 0, 1500m },
                    { 8, "GD1G/13005/5", null, "8", 0, 10m },
                    { 17, "GD1G/15/1", "GD1G/00045487/1", "17", 0, 859m },
                    { 15, "GD1G/15225/1", "GD1G/00045487/1", "15", 0, 859m },
                    { 19, "GD1G/15345/1", "GD1G/00045487/1", "19", 0, 859m },
                    { 33, "GD1G/9955/6", "GD1G/100087/2", "33", 0, 149m },
                    { 32, "GD1G/9955/6", "GD1G/100087/2", "32", 0, 149m },
                    { 31, "GD1G/9955/6", "GD1G/100087/2", "31", 0, 149m },
                    { 18, "GD1G/155/1", "GD1G/00045487/1", "18", 0, 859m },
                    { 29, "GD1G/9955/1", "GD1G/100087/2", "29", 0, 120m },
                    { 28, "GD1G/9955/1", "GD1G/100087/2", "28", 0, 120m },
                    { 27, "GD1G/9955/1", "GD1G/100087/2", "27", 0, 120m },
                    { 30, "GD1G/9955/6", "GD1G/100087/2", "30", 0, 120m },
                    { 25, "GD1G/9955/1", "GD1G/00045487/1", "25", 0, 120m },
                    { 24, "GD1G/9955/1", "GD1G/00045487/1", "24", 0, 120m },
                    { 23, "GD1G/1855/1", "GD1G/00045487/1", "23", 0, 120m },
                    { 22, "GD1G/1855/1", "GD1G/00045487/1", "22", 0, 120m },
                    { 21, "GD1G/34234/1", "GD1G/00045487/1", "21", 0, 120m },
                    { 20, "GD1G/152325/1", "GD1G/00045487/1", "20", 0, 859m },
                    { 26, "GD1G/9955/1", "GD1G/00045487/1", "25", 0, 120m }
                });

            migrationBuilder.InsertData(
                table: "GminaSlo",
                columns: new[] { "GminaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 6, "gmina Żukowo" },
                    { 1, "miasto Gdańsk" },
                    { 2, "miasto Sopot" },
                    { 3, "miasto Pruszcz Gdański" },
                    { 4, "gmina Gdańsk" },
                    { 5, "gmina Pruszcz Gdański" },
                    { 7, "gmina Kolbudy" }
                });

            migrationBuilder.InsertData(
                table: "Obreb",
                columns: new[] { "ObrebId", "DzialkaId", "GminaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, null, 1, "010" },
                    { 23, null, 4, "030" },
                    { 22, null, 3, "020" },
                    { 21, null, 3, "010" },
                    { 20, null, 2, "070" },
                    { 19, null, 2, "060" },
                    { 18, null, 2, "050" },
                    { 17, null, 2, "040" },
                    { 16, null, 2, "030" },
                    { 15, null, 2, "020" },
                    { 14, null, 2, "010" },
                    { 24, null, 4, "040" },
                    { 13, null, 1, "130" },
                    { 11, null, 1, "110" },
                    { 10, null, 1, "100" },
                    { 9, null, 1, "090" },
                    { 8, null, 1, "080" },
                    { 7, null, 1, "070" },
                    { 6, null, 1, "060" },
                    { 5, null, 1, "050" },
                    { 4, null, 1, "040" },
                    { 3, null, 1, "030" },
                    { 2, null, 1, "020" },
                    { 12, null, 1, "120" },
                    { 25, null, 4, "050" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obreb_DzialkaId",
                table: "Obreb",
                column: "DzialkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obreb_GminaSloId",
                table: "Obreb",
                column: "GminaSloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obreb");

            migrationBuilder.DropTable(
                name: "Dzialka");

            migrationBuilder.DropTable(
                name: "GminaSlo");
        }
    }
}
