using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InnePrawa",
                table: "InnePrawa");

            migrationBuilder.DropColumn(
                name: "InnePrawaId",
                table: "InnePrawa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InnePrawa",
                table: "InnePrawa",
                columns: new[] { "PodmiotId", "DzialkaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlatnoscInnePrawa_InnePrawa_DzialkaId_PodmiotId",
                table: "PlatnoscInnePrawa",
                columns: new[] { "DzialkaId", "PodmiotId" },
                principalTable: "InnePrawa",
                principalColumns: new[] { "PodmiotId", "DzialkaId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatnoscInnePrawa_InnePrawa_DzialkaId_PodmiotId",
                table: "PlatnoscInnePrawa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InnePrawa",
                table: "InnePrawa");

            migrationBuilder.AddColumn<int>(
                name: "InnePrawaId",
                table: "InnePrawa",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InnePrawa",
                table: "InnePrawa",
                column: "InnePrawaId");
        }
    }
}
