using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DzialkaOchrona",
                columns: table => new
                {
                    DzialkaOchronaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: true),
                    obszarChroniony = table.Column<bool>(nullable: false),
                    wpisDoGEZ = table.Column<bool>(nullable: false),
                    wpisDoWEZ = table.Column<bool>(nullable: false),
                    wpisDoWZ = table.Column<bool>(nullable: false),
                    wpisDoMPZP = table.Column<bool>(nullable: false),
                    parkNarodowy = table.Column<bool>(nullable: false),
                    rezerwatPrzyrody = table.Column<bool>(nullable: false),
                    parkKrajobrazowy = table.Column<bool>(nullable: false),
                    obszarChronionyKrajobrazu = table.Column<bool>(nullable: false),
                    obszarNatura2000 = table.Column<bool>(nullable: false),
                    pomnikPrzyrody = table.Column<bool>(nullable: false),
                    stonowiskoDok = table.Column<bool>(nullable: false),
                    uzytekEkologiczny = table.Column<bool>(nullable: false),
                    wpisWMPZM = table.Column<bool>(nullable: false),
                    terenOchrBezp = table.Column<bool>(nullable: false),
                    terenOchrScislej = table.Column<bool>(nullable: false),
                    terenOchrPosr = table.Column<bool>(nullable: false),
                    planObowiazujacy = table.Column<bool>(nullable: false),
                    planProcedowany = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DzialkaOchrona", x => x.DzialkaOchronaId);
                    table.ForeignKey(
                        name: "FK_DzialkaOchrona_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DzialkaOchrona_DzialkaId",
                table: "DzialkaOchrona",
                column: "DzialkaId",
                unique: true,
                filter: "[DzialkaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DzialkaOchrona");
        }
    }
}
