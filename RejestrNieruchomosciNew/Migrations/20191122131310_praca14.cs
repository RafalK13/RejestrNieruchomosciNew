using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_CelNabycia_CelNabyciaId",
                table: "Wladanie");

            migrationBuilder.DropTable(
                name: "CelNabycia");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_CelNabyciaId",
                table: "Wladanie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CelNabycia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    Rodzaj = table.Column<string>(nullable: true),
                    guid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelNabycia", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_CelNabyciaId",
                table: "Wladanie",
                column: "CelNabyciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_CelNabycia_CelNabyciaId",
                table: "Wladanie",
                column: "CelNabyciaId",
                principalTable: "CelNabycia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
