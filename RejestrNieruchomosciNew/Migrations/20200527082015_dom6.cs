using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_UliceSlo_UlicaSloId",
                table: "Adres");

            migrationBuilder.AlterColumn<int>(
                name: "UlicaSloId",
                table: "Adres",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_UliceSlo_UlicaSloId",
                table: "Adres",
                column: "UlicaSloId",
                principalTable: "UliceSlo",
                principalColumn: "UlicaSloId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_UliceSlo_UlicaSloId",
                table: "Adres");

            migrationBuilder.AlterColumn<int>(
                name: "UlicaSloId",
                table: "Adres",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_UliceSlo_UlicaSloId",
                table: "Adres",
                column: "UlicaSloId",
                principalTable: "UliceSlo",
                principalColumn: "UlicaSloId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
