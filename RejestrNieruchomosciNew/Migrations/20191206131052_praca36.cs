using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PlatnoscUW_Dzialka_DzialkaId",
            //    table: "PlatnoscUW");

            //migrationBuilder.DropTable(
            //    name: "NabyciePrawa");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PlatnoscUW_Dzialka_DzialkaId",
            //    table: "PlatnoscUW",
            //    column: "DzialkaId",
            //    principalTable: "Dzialka",
            //    principalColumn: "DzialkaId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_PlatnoscUW_Dzialka_DzialkaId",
        //        table: "PlatnoscUW");

        //    migrationBuilder.CreateTable(
        //        name: "NabyciePrawa",
        //        columns: table => new
        //        {
        //            NabyciePrawaId = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ObowiazywanieDo = table.Column<DateTime>(nullable: false),
        //            ObowiazywanieOd = table.Column<DateTime>(nullable: false),
        //            ProtokolPrzejecia = table.Column<string>(nullable: true),
        //            Skan = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_NabyciePrawa", x => x.NabyciePrawaId);
        //        });

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_PlatnoscUW_Dzialka_DzialkaId",
        //        table: "PlatnoscUW",
        //        column: "DzialkaId",
        //        principalTable: "Dzialka",
        //        principalColumn: "DzialkaId",
        //        onDelete: ReferentialAction.Restrict);
        }
    }
}
