using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class w11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Transakcje_TransakcjeSloId",
                table: "Wladanie");

            migrationBuilder.RenameColumn(
                name: "TransakcjeSloId",
                table: "Wladanie",
                newName: "TransakcjeId");

            migrationBuilder.RenameIndex(
                name: "IX_Wladanie_TransakcjeSloId",
                table: "Wladanie",
                newName: "IX_Wladanie_TransakcjeId");

            migrationBuilder.RenameColumn(
                name: "TransakcjeSloId",
                table: "Transakcje",
                newName: "TransakcjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Transakcje_TransakcjeId",
                table: "Wladanie",
                column: "TransakcjeId",
                principalTable: "Transakcje",
                principalColumn: "TransakcjeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Transakcje_TransakcjeId",
                table: "Wladanie");

            migrationBuilder.RenameColumn(
                name: "TransakcjeId",
                table: "Wladanie",
                newName: "TransakcjeSloId");

            migrationBuilder.RenameIndex(
                name: "IX_Wladanie_TransakcjeId",
                table: "Wladanie",
                newName: "IX_Wladanie_TransakcjeSloId");

            migrationBuilder.RenameColumn(
                name: "TransakcjeId",
                table: "Transakcje",
                newName: "TransakcjeSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Transakcje_TransakcjeSloId",
                table: "Wladanie",
                column: "TransakcjeSloId",
                principalTable: "Transakcje",
                principalColumn: "TransakcjeSloId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
