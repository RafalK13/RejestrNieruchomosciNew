using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class trans2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransS_Id",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_TransS_Id",
                table: "Wladanie",
                column: "TransS_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Transakcje_TransS_Id",
                table: "Wladanie",
                column: "TransS_Id",
                principalTable: "Transakcje",
                principalColumn: "TransakcjeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Transakcje_TransS_Id",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_TransS_Id",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "TransS_Id",
                table: "Wladanie");
        }
    }
}
