using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wladanie_Podmiot_PodmiotId",
                table: "Wladanie");

            migrationBuilder.DropTable(
                name: "Podmiot");

            migrationBuilder.DropIndex(
                name: "IX_Wladanie_PodmiotId",
                table: "Wladanie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Podmiot",
                columns: table => new
                {
                    PodmiotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    Kontakt = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    TaxNumber = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podmiot", x => x.PodmiotId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wladanie_PodmiotId",
                table: "Wladanie",
                column: "PodmiotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wladanie_Podmiot_PodmiotId",
                table: "Wladanie",
                column: "PodmiotId",
                principalTable: "Podmiot",
                principalColumn: "PodmiotId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
