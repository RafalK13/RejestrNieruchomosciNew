using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 13);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { 2, "Komercyjna" },
                    { 13, "13Komercyjna" }
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
        }
    }
}
