using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Dzialka_DzialkaId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie");

            migrationBuilder.AlterColumn<int>(
                name: "DzialkaId",
                table: "Wladanie",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie",
                column: "DzialkaId",
                unique: true,
                filter: "[DzialkaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Dzialka_DzialkaId",
                table: "Wladanie",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Dzialka_DzialkaId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie");

            migrationBuilder.AlterColumn<int>(
                name: "DzialkaId",
                table: "Wladanie",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_DzialkaId",
                table: "Wladanie",
                column: "DzialkaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Dzialka_DzialkaId",
                table: "Wladanie",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
