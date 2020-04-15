using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_UzytkiSlo_UzytkiSloId",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_UzytkiSloId",
                table: "Adres");

            migrationBuilder.DropColumn(
                name: "UzytkiSloId",
                table: "Adres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UzytkiSloId",
                table: "Adres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adres_UzytkiSloId",
                table: "Adres",
                column: "UzytkiSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_UzytkiSlo_UzytkiSloId",
                table: "Adres",
                column: "UzytkiSloId",
                principalTable: "UzytkiSlo",
                principalColumn: "UzytkiSloId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
