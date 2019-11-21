using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProtPrzejecia",
                table: "Wladanie",
                newName: "NrProtPrzejecia");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataProtPrzej",
                table: "Wladanie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataProtPrzej",
                table: "Wladanie");

            migrationBuilder.RenameColumn(
                name: "NrProtPrzejecia",
                table: "Wladanie",
                newName: "ProtPrzejecia");
        }
    }
}
