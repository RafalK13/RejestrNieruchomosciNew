using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca61 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatnoscInnePrawa_InnePrawa_DzialkaId_PodmiotId",
                table: "PlatnoscInnePrawa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_PlatnoscInnePrawa_InnePrawa_DzialkaId_PodmiotId",
                table: "PlatnoscInnePrawa",
                columns: new[] { "DzialkaId", "PodmiotId" },
                principalTable: "InnePrawa",
                principalColumns: new[] { "PodmiotId", "DzialkaId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
