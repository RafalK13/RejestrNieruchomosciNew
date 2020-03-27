using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skan",
                table: "Transakcje");

            migrationBuilder.CreateTable(
                name: "Budynek",
                columns: table => new
                {
                    BudynekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: false),
                    powBezPiwnic = table.Column<double>(nullable: false),
                    powPiwnic = table.Column<double>(nullable: false),
                    powCalk = table.Column<double>(nullable: false),
                    powZabud = table.Column<double>(nullable: false),
                    kubatura = table.Column<double>(nullable: false),
                    iloscKond = table.Column<int>(nullable: false),
                    NumerEwid = table.Column<double>(nullable: false),
                    wpisRejZab = table.Column<bool>(nullable: false),
                    MediaId = table.Column<int>(nullable: false),
                    stanTech = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budynek", x => x.BudynekId);
                });

            migrationBuilder.CreateTable(
                name: "Dzialka_Budynek",
                columns: table => new
                {
                    DzialkaId = table.Column<int>(nullable: false),
                    BudynekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzialka_Budynek", x => new { x.BudynekId, x.DzialkaId });
                    table.ForeignKey(
                        name: "FK_Dzialka_Budynek_Budynek_BudynekId",
                        column: x => x.BudynekId,
                        principalTable: "Budynek",
                        principalColumn: "BudynekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dzialka_Budynek_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_Budynek_DzialkaId",
                table: "Dzialka_Budynek",
                column: "DzialkaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dzialka_Budynek");

            migrationBuilder.DropTable(
                name: "Budynek");

            migrationBuilder.AddColumn<string>(
                name: "Skan",
                table: "Transakcje",
                nullable: true);
        }
    }
}
