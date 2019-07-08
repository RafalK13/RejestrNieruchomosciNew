using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class r7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Numer",
                table: "Dzialka",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_Numer_ObrebId",
                table: "Dzialka",
                columns: new[] { "Numer", "ObrebId" },
                unique: true,
                filter: "[Numer] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dzialka_Numer_ObrebId",
                table: "Dzialka");

            migrationBuilder.AlterColumn<string>(
                name: "Numer",
                table: "Dzialka",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
