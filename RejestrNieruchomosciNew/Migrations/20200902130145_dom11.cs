using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokal_Podmiot",
                columns: table => new
                {
                    Lokal_PodmiotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LokalId = table.Column<int>(nullable: false),
                    PodmiotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokal_Podmiot", x => x.Lokal_PodmiotId);
                    table.ForeignKey(
                        name: "FK_Lokal_Podmiot_Lokal_LokalId",
                        column: x => x.LokalId,
                        principalTable: "Lokal",
                        principalColumn: "LokalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lokal_Podmiot_LokalId",
                table: "Lokal_Podmiot",
                column: "LokalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokal_Podmiot");
        }
    }
}
