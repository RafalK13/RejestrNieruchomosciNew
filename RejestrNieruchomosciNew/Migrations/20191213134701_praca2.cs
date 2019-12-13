using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatnoscInnePrawa_InnePrawa_DzialkaId_PodmiotId",
                table: "PlatnoscInnePrawa");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatnoscInnePrawa_InnePrawa_DzialkaId_PodmiotId",
                table: "PlatnoscInnePrawa",
                columns: new[] { "DzialkaId", "PodmiotId" },
                principalTable: "InnePrawa",
                principalColumns: new[] { "DzialkaId", "PodmiotId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatnoscInnePrawa_InnePrawa_DzialkaId_PodmiotId",
                table: "PlatnoscInnePrawa");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatnoscInnePrawa_InnePrawa_DzialkaId_PodmiotId",
                table: "PlatnoscInnePrawa",
                columns: new[] { "DzialkaId", "PodmiotId" },
                principalTable: "InnePrawa",
                principalColumns: new[] { "DzialkaId", "PodmiotId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
