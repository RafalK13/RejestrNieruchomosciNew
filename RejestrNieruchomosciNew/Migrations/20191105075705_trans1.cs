using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class trans1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Transakcje_TransakcjeId",
                table: "Wladanie");

            migrationBuilder.RenameColumn(
                name: "TransakcjeId",
                table: "Wladanie",
                newName: "TransK_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Wladanie_TransakcjeId",
                table: "Wladanie",
                newName: "IX_Wladanie_TransK_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Transakcje_TransK_Id",
                table: "Wladanie",
                column: "TransK_Id",
                principalTable: "Transakcje",
                principalColumn: "TransakcjeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Transakcje_TransK_Id",
                table: "Wladanie");

            migrationBuilder.RenameColumn(
                name: "TransK_Id",
                table: "Wladanie",
                newName: "TransakcjeId");

            migrationBuilder.RenameIndex(
                name: "IX_Wladanie_TransK_Id",
                table: "Wladanie",
                newName: "IX_Wladanie_TransakcjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Transakcje_TransakcjeId",
                table: "Wladanie",
                column: "TransakcjeId",
                principalTable: "Transakcje",
                principalColumn: "TransakcjeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
