using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zagosp_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                table: "Zagosp");

            migrationBuilder.DropForeignKey(
                name: "FK_Zagosp_ZagospStatusSlo_ZagospStatusSloId",
                table: "Zagosp");

            migrationBuilder.AlterColumn<int>(
                name: "zadInwestSloId",
                table: "Zagosp",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "przedstSloId",
                table: "Zagosp",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "obiektyKomSloId",
                table: "Zagosp",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "istObiektySloId",
                table: "Zagosp",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "celeKomSloId",
                table: "Zagosp",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ZagospStatusSloId",
                table: "Zagosp",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ZagospFunkcjaSloId",
                table: "Zagosp",
                nullable: true,
                oldClrType: typeof(int));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zagosp_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                table: "Zagosp");

            migrationBuilder.DropForeignKey(
                name: "FK_Zagosp_ZagospStatusSlo_ZagospStatusSloId",
                table: "Zagosp");

            migrationBuilder.AlterColumn<int>(
                name: "zadInwestSloId",
                table: "Zagosp",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "przedstSloId",
                table: "Zagosp",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "obiektyKomSloId",
                table: "Zagosp",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "istObiektySloId",
                table: "Zagosp",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "celeKomSloId",
                table: "Zagosp",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZagospStatusSloId",
                table: "Zagosp",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZagospFunkcjaSloId",
                table: "Zagosp",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zagosp_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                table: "Zagosp",
                column: "ZagospFunkcjaSloId",
                principalTable: "ZagospFunkcjaSlo",
                principalColumn: "ZagospFunkcjaSloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zagosp_ZagospStatusSlo_ZagospStatusSloId",
                table: "Zagosp",
                column: "ZagospStatusSloId",
                principalTable: "ZagospStatusSlo",
                principalColumn: "ZagospStatusSloId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
