using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
