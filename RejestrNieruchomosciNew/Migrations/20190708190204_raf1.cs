using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class raf1 : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
