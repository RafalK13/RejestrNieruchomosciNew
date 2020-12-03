using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ZagospFunkcjaSlo",
                columns: new[] { "ZagospFunkcjaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "wodociągowa" },
                    { 2, "kanlizacyjna" },
                    { 3, "energetyczna" },
                    { 4, "mieszana" },
                    { 5, "społeczna" },
                    { 6, "użytkowa" },
                    { 7, "finansowa" },
                    { 8, "mieszana" }
                });

            migrationBuilder.InsertData(
                table: "ZagospStatusSlo",
                columns: new[] { "ZagospStatusSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Wod/Kan/Energ" },
                    { 2, "Komercyjna" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 2);
        }
    }
}
