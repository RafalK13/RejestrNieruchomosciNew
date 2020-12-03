using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
