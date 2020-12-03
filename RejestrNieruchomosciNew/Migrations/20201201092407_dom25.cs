using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZagospStatus_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                table: "ZagospStatus");

            migrationBuilder.DropColumn(
                name: "ZagospFunctSloId",
                table: "ZagospStatus");

            migrationBuilder.AlterColumn<int>(
                name: "ZagospFunkcjaSloId",
                table: "ZagospStatus",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 1,
                column: "ZagospFunkcjaSloId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 2,
                column: "ZagospFunkcjaSloId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 3,
                column: "ZagospFunkcjaSloId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 4,
                column: "ZagospFunkcjaSloId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 5,
                column: "ZagospFunkcjaSloId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 6,
                column: "ZagospFunkcjaSloId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 7,
                column: "ZagospFunkcjaSloId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 8,
                column: "ZagospFunkcjaSloId",
                value: 8);

            migrationBuilder.AddForeignKey(
                name: "FK_ZagospStatus_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                table: "ZagospStatus",
                column: "ZagospFunkcjaSloId",
                principalTable: "ZagospFunkcjaSlo",
                principalColumn: "ZagospFunkcjaSloId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZagospStatus_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                table: "ZagospStatus");

            migrationBuilder.AlterColumn<int>(
                name: "ZagospFunkcjaSloId",
                table: "ZagospStatus",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ZagospFunctSloId",
                table: "ZagospStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 1,
                columns: new[] { "ZagospFunctSloId", "ZagospFunkcjaSloId" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 2,
                columns: new[] { "ZagospFunctSloId", "ZagospFunkcjaSloId" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 3,
                columns: new[] { "ZagospFunctSloId", "ZagospFunkcjaSloId" },
                values: new object[] { 3, null });

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 4,
                columns: new[] { "ZagospFunctSloId", "ZagospFunkcjaSloId" },
                values: new object[] { 4, null });

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 5,
                columns: new[] { "ZagospFunctSloId", "ZagospFunkcjaSloId" },
                values: new object[] { 5, null });

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 6,
                columns: new[] { "ZagospFunctSloId", "ZagospFunkcjaSloId" },
                values: new object[] { 6, null });

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 7,
                columns: new[] { "ZagospFunctSloId", "ZagospFunkcjaSloId" },
                values: new object[] { 7, null });

            migrationBuilder.UpdateData(
                table: "ZagospStatus",
                keyColumn: "ZagospStatusId",
                keyValue: 8,
                columns: new[] { "ZagospFunctSloId", "ZagospFunkcjaSloId" },
                values: new object[] { 8, null });

            migrationBuilder.AddForeignKey(
                name: "FK_ZagospStatus_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                table: "ZagospStatus",
                column: "ZagospFunkcjaSloId",
                principalTable: "ZagospFunkcjaSlo",
                principalColumn: "ZagospFunkcjaSloId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
