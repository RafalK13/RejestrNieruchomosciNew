using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatnoscUW_NabyciePrawa_NabyciePrawaId",
                table: "PlatnoscUW");

            migrationBuilder.DropIndex(
                name: "IX_PlatnoscUW_NabyciePrawaId",
                table: "PlatnoscUW");

            migrationBuilder.DropColumn(
                name: "NabyciePrawaId",
                table: "PlatnoscUW");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NabyciePrawaId",
                table: "PlatnoscUW",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatnoscUW_NabyciePrawaId",
                table: "PlatnoscUW",
                column: "NabyciePrawaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatnoscUW_NabyciePrawa_NabyciePrawaId",
                table: "PlatnoscUW",
                column: "NabyciePrawaId",
                principalTable: "NabyciePrawa",
                principalColumn: "NabyciePrawaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
