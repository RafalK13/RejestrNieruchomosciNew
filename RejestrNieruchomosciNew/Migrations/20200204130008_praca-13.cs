using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ZagospFunkcjaSlo",
                columns: new[] { "ZagospFunkcjaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "społeczna" },
                    { 3, "użytkowa" },
                    { 4, "finansowa" },
                    { 5, "mieszana" }
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
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 5);
        }
    }
}
