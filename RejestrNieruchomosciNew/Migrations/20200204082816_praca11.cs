using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZagospFunkcjaSlo",
                columns: table => new
                {
                    ZagospFunkcjaSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZagospFunkcjaSlo", x => x.ZagospFunkcjaSloId);
                });

            migrationBuilder.CreateTable(
                name: "ZagospStatusSlo",
                columns: table => new
                {
                    ZagospStatusSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZagospStatusSlo", x => x.ZagospStatusSloId);
                });

            migrationBuilder.CreateTable(
                name: "Zagosp",
                columns: table => new
                {
                    ZagospId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true),
                    ZagospStatusSloId = table.Column<int>(nullable: false),
                    ZagospFunkcjaSloId = table.Column<int>(nullable: false),
                    istObiektySloId = table.Column<int>(nullable: false),
                    obiektyKomSloId = table.Column<int>(nullable: false),
                    zadInwestSloId = table.Column<int>(nullable: false),
                    celeKomSloId = table.Column<int>(nullable: false),
                    przedstSloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zagosp", x => x.ZagospId);
                    table.ForeignKey(
                        name: "FK_Zagosp_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zagosp_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                        column: x => x.ZagospFunkcjaSloId,
                        principalTable: "ZagospFunkcjaSlo",
                        principalColumn: "ZagospFunkcjaSloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zagosp_ZagospStatusSlo_ZagospStatusSloId",
                        column: x => x.ZagospStatusSloId,
                        principalTable: "ZagospStatusSlo",
                        principalColumn: "ZagospStatusSloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zagosp_DzialkaId",
                table: "Zagosp",
                column: "DzialkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zagosp_ZagospFunkcjaSloId",
                table: "Zagosp",
                column: "ZagospFunkcjaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Zagosp_ZagospStatusSloId",
                table: "Zagosp",
                column: "ZagospStatusSloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zagosp");

            migrationBuilder.DropTable(
                name: "ZagospFunkcjaSlo");

            migrationBuilder.DropTable(
                name: "ZagospStatusSlo");
        }
    }
}
