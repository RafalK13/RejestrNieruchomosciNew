using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UliceSlo_GminaSlo_GminaSloId",
                table: "UliceSlo");

            migrationBuilder.DropIndex(
                name: "IX_UliceSlo_GminaSloId",
                table: "UliceSlo");

            migrationBuilder.DropColumn(
                name: "GminaSloId",
                table: "UliceSlo");

            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Dzialka",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Dzialka");

            migrationBuilder.AddColumn<int>(
                name: "GminaSloId",
                table: "UliceSlo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UliceSlo_GminaSloId",
                table: "UliceSlo",
                column: "GminaSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_UliceSlo_GminaSlo_GminaSloId",
                table: "UliceSlo",
                column: "GminaSloId",
                principalTable: "GminaSlo",
                principalColumn: "GminaSloId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
