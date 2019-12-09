using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class praca51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Dzialka_PlatnoscUW_DzialkaId",
            //    table: "Dzialka");

            //migrationBuilder.AlterColumn<int>(
            //    name: "DzialkaId",
            //    table: "Dzialka",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PlatnoscUW_DzialkaId",
            //    table: "PlatnoscUW",
            //    column: "DzialkaId",
            //    unique: true,
            //    filter: "[DzialkaId] IS NOT NULL");

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
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PlatnoscUW_Dzialka_DzialkaId",
            //    table: "PlatnoscUW");

            //migrationBuilder.DropIndex(
            //    name: "IX_PlatnoscUW_DzialkaId",
            //    table: "PlatnoscUW");

            //migrationBuilder.AlterColumn<int>(
            //    name: "DzialkaId",
            //    table: "Dzialka",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Dzialka_PlatnoscUW_DzialkaId",
            //    table: "Dzialka",
            //    column: "DzialkaId",
            //    principalTable: "PlatnoscUW",
            //    principalColumn: "PlatnoscUWId",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
