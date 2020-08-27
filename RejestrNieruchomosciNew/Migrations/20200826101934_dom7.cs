using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokal",
                columns: table => new
                {
                    LokalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numer = table.Column<string>(nullable: true),
                    pow = table.Column<double>(nullable: false),
                    powPomPrzyn = table.Column<double>(nullable: false),
                    opis = table.Column<string>(nullable: true),
                    media = table.Column<int>(nullable: false),
                    kondygnacja = table.Column<int>(nullable: false),
                    KWlok = table.Column<string>(nullable: true),
                    NajemcaId = table.Column<int>(nullable: false),
                    BudynekId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokal", x => x.LokalId);
                    table.ForeignKey(
                        name: "FK_Lokal_Budynek_BudynekId",
                        column: x => x.BudynekId,
                        principalTable: "Budynek",
                        principalColumn: "BudynekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lokal_BudynekId",
                table: "Lokal",
                column: "BudynekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokal");
        }
    }
}
