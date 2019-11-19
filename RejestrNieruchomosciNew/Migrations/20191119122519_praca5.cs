using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_NabyciePrawa_NabyciePrawaId",
                table: "Wladanie");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_NabyciePrawaId",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "NabycieId",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "NabyciePrawaId",
                table: "Wladanie");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataOdbDo",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataOdbOd",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProtPrzejecia",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Scan",
                table: "Wladanie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataOdbDo",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "DataOdbOd",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "ProtPrzejecia",
                table: "Wladanie");

            migrationBuilder.DropColumn(
                name: "Scan",
                table: "Wladanie");

            migrationBuilder.AddColumn<int>(
                name: "NabycieId",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NabyciePrawaId",
                table: "Wladanie",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_NabyciePrawaId",
                table: "Wladanie",
                column: "NabyciePrawaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_NabyciePrawa_NabyciePrawaId",
                table: "Wladanie",
                column: "NabyciePrawaId",
                principalTable: "NabyciePrawa",
                principalColumn: "NabyciePrawaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
