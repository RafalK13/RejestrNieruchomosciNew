using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zagosp_Dzialka_DzialkaId",
                table: "Zagosp");

            migrationBuilder.DropForeignKey(
                name: "FK_Zagosp_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                table: "Zagosp");

            migrationBuilder.DropForeignKey(
                name: "FK_Zagosp_ZagospStatusSlo_ZagospStatusSloId",
                table: "Zagosp");

            migrationBuilder.DropIndex(
                name: "IX_Zagosp_DzialkaId",
                table: "Zagosp");

            migrationBuilder.DropIndex(
                name: "IX_Zagosp_ZagospFunkcjaSloId",
                table: "Zagosp");

            migrationBuilder.DropIndex(
                name: "IX_Zagosp_ZagospStatusSloId",
                table: "Zagosp");

            migrationBuilder.DropColumn(
                name: "ZagospFunkcjaSloId",
                table: "Zagosp");

            migrationBuilder.AddColumn<int>(
                name: "ZagospFunkcjaSloId",
                table: "ZagospStatusSlo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZagospId",
                table: "ZagospStatusSlo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZagospStatusSloId",
                table: "ZagospFunkcjaSlo",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DzialkaId",
                table: "Zagosp",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ZagospStatusSlo_ZagospId",
                table: "ZagospStatusSlo",
                column: "ZagospId",
                unique: true,
                filter: "[ZagospId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ZagospFunkcjaSlo_ZagospStatusSloId",
                table: "ZagospFunkcjaSlo",
                column: "ZagospStatusSloId");

            migrationBuilder.CreateIndex(
                name: "IX_Zagosp_DzialkaId",
                table: "Zagosp",
                column: "DzialkaId",
                unique: true,
                filter: "[DzialkaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Zagosp_Dzialka_DzialkaId",
                table: "Zagosp",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZagospFunkcjaSlo_ZagospStatusSlo_ZagospStatusSloId",
                table: "ZagospFunkcjaSlo",
                column: "ZagospStatusSloId",
                principalTable: "ZagospStatusSlo",
                principalColumn: "ZagospStatusSloId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZagospStatusSlo_Zagosp_ZagospId",
                table: "ZagospStatusSlo",
                column: "ZagospId",
                principalTable: "Zagosp",
                principalColumn: "ZagospId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zagosp_Dzialka_DzialkaId",
                table: "Zagosp");

            migrationBuilder.DropForeignKey(
                name: "FK_ZagospFunkcjaSlo_ZagospStatusSlo_ZagospStatusSloId",
                table: "ZagospFunkcjaSlo");

            migrationBuilder.DropForeignKey(
                name: "FK_ZagospStatusSlo_Zagosp_ZagospId",
                table: "ZagospStatusSlo");

            migrationBuilder.DropIndex(
                name: "IX_ZagospStatusSlo_ZagospId",
                table: "ZagospStatusSlo");

            migrationBuilder.DropIndex(
                name: "IX_ZagospFunkcjaSlo_ZagospStatusSloId",
                table: "ZagospFunkcjaSlo");

            migrationBuilder.DropIndex(
                name: "IX_Zagosp_DzialkaId",
                table: "Zagosp");

            migrationBuilder.DropColumn(
                name: "ZagospFunkcjaSloId",
                table: "ZagospStatusSlo");

            migrationBuilder.DropColumn(
                name: "ZagospId",
                table: "ZagospStatusSlo");

            migrationBuilder.DropColumn(
                name: "ZagospStatusSloId",
                table: "ZagospFunkcjaSlo");

            migrationBuilder.AlterColumn<int>(
                name: "DzialkaId",
                table: "Zagosp",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZagospFunkcjaSloId",
                table: "Zagosp",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Zagosp_Dzialka_DzialkaId",
                table: "Zagosp",
                column: "DzialkaId",
                principalTable: "Dzialka",
                principalColumn: "DzialkaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zagosp_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                table: "Zagosp",
                column: "ZagospFunkcjaSloId",
                principalTable: "ZagospFunkcjaSlo",
                principalColumn: "ZagospFunkcjaSloId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zagosp_ZagospStatusSlo_ZagospStatusSloId",
                table: "Zagosp",
                column: "ZagospStatusSloId",
                principalTable: "ZagospStatusSlo",
                principalColumn: "ZagospStatusSloId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
