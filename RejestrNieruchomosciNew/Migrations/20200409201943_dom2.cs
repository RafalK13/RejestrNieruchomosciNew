using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dzialka_UliceSlo_UliceSloId",
                table: "Dzialka");

            migrationBuilder.DropForeignKey(
                name: "FK_UliceSlo_GminaSlo_GminaSloId",
                table: "UliceSlo");

            migrationBuilder.DropIndex(
                name: "IX_Dzialka_UliceSloId",
                table: "Dzialka");

            migrationBuilder.DropColumn(
                name: "UliceSloId",
                table: "Dzialka");

            migrationBuilder.RenameColumn(
                name: "UliceSloId",
                table: "UliceSlo",
                newName: "UlicaSloId");

            migrationBuilder.AlterColumn<int>(
                name: "GminaSloId",
                table: "UliceSlo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MiejscowoscUlice",
                table: "UliceSlo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MiejscowoscSlo",
                columns: table => new
                {
                    MiejscowoscSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GminaSloId = table.Column<int>(nullable: false),
                    MiejscowoscUlice = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiejscowoscSlo", x => x.MiejscowoscSloId);
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    AdresId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DzialkaId = table.Column<int>(nullable: true),
                    Numer = table.Column<string>(nullable: true),
                    MiejscowoscSloId = table.Column<int>(nullable: false),
                    UlicaSloId = table.Column<int>(nullable: false),
                    UzytkiSloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.AdresId);
                    table.ForeignKey(
                        name: "FK_Adres_Dzialka_DzialkaId",
                        column: x => x.DzialkaId,
                        principalTable: "Dzialka",
                        principalColumn: "DzialkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adres_MiejscowoscSlo_MiejscowoscSloId",
                        column: x => x.MiejscowoscSloId,
                        principalTable: "MiejscowoscSlo",
                        principalColumn: "MiejscowoscSloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adres_UliceSlo_UlicaSloId",
                        column: x => x.UlicaSloId,
                        principalTable: "UliceSlo",
                        principalColumn: "UlicaSloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adres_UzytkiSlo_UzytkiSloId",
                        column: x => x.UzytkiSloId,
                        principalTable: "UzytkiSlo",
                        principalColumn: "UzytkiSloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_DzialkaId",
                table: "Adres",
                column: "DzialkaId",
                unique: true,
                filter: "[DzialkaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_MiejscowoscSloId",
                table: "Adres",
                column: "MiejscowoscSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_UlicaSloId",
                table: "Adres",
                column: "UlicaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_UzytkiSloId",
                table: "Adres",
                column: "UzytkiSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_UliceSlo_GminaSlo_GminaSloId",
                table: "UliceSlo",
                column: "GminaSloId",
                principalTable: "GminaSlo",
                principalColumn: "GminaSloId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UliceSlo_GminaSlo_GminaSloId",
                table: "UliceSlo");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "MiejscowoscSlo");

            migrationBuilder.DropColumn(
                name: "MiejscowoscUlice",
                table: "UliceSlo");

            migrationBuilder.RenameColumn(
                name: "UlicaSloId",
                table: "UliceSlo",
                newName: "UliceSloId");

            migrationBuilder.AlterColumn<int>(
                name: "GminaSloId",
                table: "UliceSlo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UliceSloId",
                table: "Dzialka",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_UliceSloId",
                table: "Dzialka",
                column: "UliceSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dzialka_UliceSlo_UliceSloId",
                table: "Dzialka",
                column: "UliceSloId",
                principalTable: "UliceSlo",
                principalColumn: "UliceSloId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UliceSlo_GminaSlo_GminaSloId",
                table: "UliceSlo",
                column: "GminaSloId",
                principalTable: "GminaSlo",
                principalColumn: "GminaSloId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
