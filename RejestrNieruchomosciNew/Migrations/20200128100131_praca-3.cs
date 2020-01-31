using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "RodzajInnegoPrawaSlo",
                columns: new[] { "RodzajInnegoPrawaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 7, "bezumowne" },
                    { 5, "służebność" },
                    { 4, "użyczenie" },
                    { 6, "czasowe zajęcie" },
                    { 2, "dzierżawa" },
                    { 1, "-" },
                    { 3, "najem" }
                });

            migrationBuilder.InsertData(
                table: "UzytkiSlo",
                columns: new[] { "UzytkiSloId", "Nazwa" },
                values: new object[,]
                {
                    { 25, "E-Ls" },
                    { 20, "Tk" },
                    { 21, "Ti" },
                    { 22, "Tp" },
                    { 23, "E-Ws" },
                    { 24, "E-Wp" },
                    { 26, "E-Lz" },
                    { 31, "E-Lzr" },
                    { 28, "E-Ps" },
                    { 29, "E-R" },
                    { 30, "E-Ł" },
                    { 19, "dr" },
                    { 32, "E-W" },
                    { 33, "Wm" },
                    { 34, "Wp" },
                    { 27, "E-N" },
                    { 18, "K" },
                    { 13, "B" },
                    { 16, "Bp" },
                    { 1, "-" },
                    { 2, "R" },
                    { 3, "S" },
                    { 4, "Ł" },
                    { 5, "Ps" },
                    { 6, "Br" },
                    { 7, "Wsr" },
                    { 8, "W" },
                    { 9, "Lzr" },
                    { 10, "N" },
                    { 11, "Ls" },
                    { 12, "Lz" },
                    { 35, "Ws" },
                    { 14, "Ba" },
                    { 15, "Bi" },
                    { 17, "Bz" },
                    { 36, "Tr" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NadzorKonserwSlo",
                keyColumn: "NadzorKonserwSloId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NadzorKonserwSlo",
                keyColumn: "NadzorKonserwSloId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NadzorKonserwSlo",
                keyColumn: "NadzorKonserwSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RodzajInnegoPrawaSlo",
                keyColumn: "RodzajInnegoPrawaSloId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RodzajInnegoPrawaSlo",
                keyColumn: "RodzajInnegoPrawaSloId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RodzajInnegoPrawaSlo",
                keyColumn: "RodzajInnegoPrawaSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RodzajInnegoPrawaSlo",
                keyColumn: "RodzajInnegoPrawaSloId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RodzajInnegoPrawaSlo",
                keyColumn: "RodzajInnegoPrawaSloId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RodzajInnegoPrawaSlo",
                keyColumn: "RodzajInnegoPrawaSloId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RodzajInnegoPrawaSlo",
                keyColumn: "RodzajInnegoPrawaSloId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "UzytkiSlo",
                keyColumn: "UzytkiSloId",
                keyValue: 36);
        }
    }
}
