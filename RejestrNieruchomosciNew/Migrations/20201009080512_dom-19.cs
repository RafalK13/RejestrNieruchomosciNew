using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "celeKomSloId",
                table: "Zagosp");

            migrationBuilder.RenameColumn(
                name: "Nazwa",
                table: "Zagosp",
                newName: "zagospKomercyjne");

            migrationBuilder.AddColumn<string>(
                name: "celeKom",
                table: "Zagosp",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "KonserwZabytkowSlo",
                keyColumn: "KonserwZabytkowSloId",
                keyValue: 4,
                column: "Nazwa",
                value: "Wojewódzka Ewidencja Zabytków");

            migrationBuilder.InsertData(
                table: "KonserwZabytkowSlo",
                columns: new[] { "KonserwZabytkowSloId", "Nazwa" },
                values: new object[] { 5, "MPZP" });

            migrationBuilder.InsertData(
                table: "PrzedstawicielSlo",
                columns: new[] { "PrzedstawicielSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "GIWK EE" },
                    { 3, "GIWK TE" },
                    { 4, "GIWK TS" },
                    { 5, "SNG" },
                    { 6, "inny" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KonserwZabytkowSlo",
                keyColumn: "KonserwZabytkowSloId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PrzedstawicielSlo",
                keyColumn: "PrzedstawicielSloId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PrzedstawicielSlo",
                keyColumn: "PrzedstawicielSloId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PrzedstawicielSlo",
                keyColumn: "PrzedstawicielSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PrzedstawicielSlo",
                keyColumn: "PrzedstawicielSloId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PrzedstawicielSlo",
                keyColumn: "PrzedstawicielSloId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PrzedstawicielSlo",
                keyColumn: "PrzedstawicielSloId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "celeKom",
                table: "Zagosp");

            migrationBuilder.RenameColumn(
                name: "zagospKomercyjne",
                table: "Zagosp",
                newName: "Nazwa");

            migrationBuilder.AddColumn<int>(
                name: "celeKomSloId",
                table: "Zagosp",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "KonserwZabytkowSlo",
                keyColumn: "KonserwZabytkowSloId",
                keyValue: 4,
                column: "Nazwa",
                value: "MPZP");
        }
    }
}
