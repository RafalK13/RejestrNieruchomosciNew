using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ZagospFunkcjaSlo_ZagospStatusSlo_ZagospStatusSloId",
            //    table: "ZagospFunkcjaSlo");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ZagospStatusSlo_Zagosp_ZagospId",
            //    table: "ZagospStatusSlo");

            migrationBuilder.DropIndex(
                name: "IX_ZagospStatusSlo_ZagospId",
                table: "ZagospStatusSlo");

            migrationBuilder.DropIndex(
                name: "IX_ZagospFunkcjaSlo_ZagospStatusSloId",
                table: "ZagospFunkcjaSlo");

            migrationBuilder.DeleteData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ZagospFunkcjaSloId",
                table: "ZagospStatusSlo");

            migrationBuilder.DropColumn(
                name: "ZagospId",
                table: "ZagospStatusSlo");

            migrationBuilder.DropColumn(
                name: "ZagospStatusSloId",
                table: "ZagospFunkcjaSlo");

            migrationBuilder.DropColumn(
                name: "ZagospStatusSloId",
                table: "Zagosp");

            migrationBuilder.DropColumn(
                name: "obiektyKomSloId",
                table: "Zagosp");

            migrationBuilder.DropColumn(
                name: "przedstSloId",
                table: "Zagosp");

            migrationBuilder.RenameColumn(
                name: "zagospKomercyjne",
                table: "Zagosp",
                newName: "WylacznieInfo");

            migrationBuilder.RenameColumn(
                name: "celeKom",
                table: "Zagosp",
                newName: "WylaczenieProt");

            migrationBuilder.AddColumn<string>(
                name: "DoWylaczenia",
                table: "Zagosp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DodatkoweZagosp",
                table: "Zagosp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanowaneZagosp",
                table: "Zagosp",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZagospStatusId",
                table: "Zagosp",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ZagospStatus",
                columns: table => new
                {
                    ZagospStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZagospStatusSloId = table.Column<int>(nullable: false),
                    ZagospFunctSloId = table.Column<int>(nullable: false),
                    ZagospFunkcjaSloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZagospStatus", x => x.ZagospStatusId);
                    table.ForeignKey(
                        name: "FK_ZagospStatus_ZagospFunkcjaSlo_ZagospFunkcjaSloId",
                        column: x => x.ZagospFunkcjaSloId,
                        principalTable: "ZagospFunkcjaSlo",
                        principalColumn: "ZagospFunkcjaSloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZagospStatus_ZagospStatusSlo_ZagospStatusSloId",
                        column: x => x.ZagospStatusSloId,
                        principalTable: "ZagospStatusSlo",
                        principalColumn: "ZagospStatusSloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 1,
                column: "Nazwa",
                value: "wodociągowa");

            migrationBuilder.UpdateData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 2,
                column: "Nazwa",
                value: "kanlizacyjna");

            migrationBuilder.UpdateData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 3,
                column: "Nazwa",
                value: "energetyczna");

            migrationBuilder.UpdateData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 4,
                column: "Nazwa",
                value: "mieszana");

            migrationBuilder.UpdateData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 5,
                column: "Nazwa",
                value: "społeczna");

            migrationBuilder.InsertData(
                table: "ZagospFunkcjaSlo",
                columns: new[] { "ZagospFunkcjaSloId", "Nazwa" },
                values: new object[,]
                {
                    { 6, "użytkowa" },
                    { 7, "finansowa" },
                    { 8, "mieszana" }
                });

            //migrationBuilder.InsertData(
            //    table: "ZagospStatus",
            //    columns: new[] { "ZagospStatusId", "ZagospFunctSloId", "ZagospFunkcjaSloId", "ZagospStatusSloId" },
            //    values: new object[,]
            //    {
            //        { 8, 8, null, 2 },
            //        { 7, 7, null, 2 },
            //        { 6, 6, null, 2 },
            //        { 5, 5, null, 2 },
            //        { 1, 1, null, 1 },
            //        { 3, 3, null, 1 },
            //        { 2, 2, null, 1 },
            //        { 4, 4, null, 1 }
            //    });

            migrationBuilder.UpdateData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 1,
                column: "Nazwa",
                value: "Wod/Kan/Energ");

            migrationBuilder.UpdateData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 2,
                column: "Nazwa",
                value: "Komercyjna");

            migrationBuilder.CreateIndex(
                name: "IX_Zagosp_ZagospStatusId",
                table: "Zagosp",
                column: "ZagospStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ZagospStatus_ZagospFunkcjaSloId",
                table: "ZagospStatus",
                column: "ZagospFunkcjaSloId");

            migrationBuilder.CreateIndex(
                name: "IX_ZagospStatus_ZagospStatusSloId",
                table: "ZagospStatus",
                column: "ZagospStatusSloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zagosp_ZagospStatus_ZagospStatusId",
                table: "Zagosp",
                column: "ZagospStatusId",
                principalTable: "ZagospStatus",
                principalColumn: "ZagospStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Zagosp_ZagospStatus_ZagospStatusId",
            //    table: "Zagosp");

            //migrationBuilder.DropTable(
            //    name: "ZagospStatus");

            migrationBuilder.DropIndex(
                name: "IX_Zagosp_ZagospStatusId",
                table: "Zagosp");

            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "DoWylaczenia",
                table: "Zagosp");

            migrationBuilder.DropColumn(
                name: "DodatkoweZagosp",
                table: "Zagosp");

            migrationBuilder.DropColumn(
                name: "PlanowaneZagosp",
                table: "Zagosp");

            migrationBuilder.DropColumn(
                name: "ZagospStatusId",
                table: "Zagosp");

            migrationBuilder.RenameColumn(
                name: "WylacznieInfo",
                table: "Zagosp",
                newName: "zagospKomercyjne");

            migrationBuilder.RenameColumn(
                name: "WylaczenieProt",
                table: "Zagosp",
                newName: "celeKom");

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

            migrationBuilder.AddColumn<int>(
                name: "ZagospStatusSloId",
                table: "Zagosp",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "obiektyKomSloId",
                table: "Zagosp",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "przedstSloId",
                table: "Zagosp",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 1,
                column: "Nazwa",
                value: "-");

            migrationBuilder.UpdateData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 2,
                column: "Nazwa",
                value: "społeczna");

            migrationBuilder.UpdateData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 3,
                column: "Nazwa",
                value: "użytkowa");

            migrationBuilder.UpdateData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 4,
                column: "Nazwa",
                value: "finansowa");

            migrationBuilder.UpdateData(
                table: "ZagospFunkcjaSlo",
                keyColumn: "ZagospFunkcjaSloId",
                keyValue: 5,
                column: "Nazwa",
                value: "mieszana");

            migrationBuilder.UpdateData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 1,
                column: "Nazwa",
                value: "-");

            migrationBuilder.UpdateData(
                table: "ZagospStatusSlo",
                keyColumn: "ZagospStatusSloId",
                keyValue: 2,
                column: "Nazwa",
                value: "wodociągowa");

            migrationBuilder.InsertData(
                table: "ZagospStatusSlo",
                columns: new[] { "ZagospStatusSloId", "Nazwa", "ZagospFunkcjaSloId", "ZagospId" },
                values: new object[,]
                {
                    { 3, "sanitarna", null, null },
                    { 4, "komercyjna", null, null },
                    { 5, "mieszana", null, null }
                });

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
    }
}
