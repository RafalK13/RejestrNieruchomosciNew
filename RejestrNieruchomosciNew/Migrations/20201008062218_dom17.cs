using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RejestrNieruchomosciNew.Migrations
{
    public partial class dom17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dzialka_NadzorKonserwSlo_NadzorKonserwSloId",
                table: "Dzialka");

            migrationBuilder.DropTable(
                name: "NadzorKonserwSlo");

            migrationBuilder.RenameColumn(
                name: "NadzorKonserwSloId",
                table: "Dzialka",
                newName: "KonserwZabytkowSloId");

            migrationBuilder.RenameIndex(
                name: "IX_Dzialka_NadzorKonserwSloId",
                table: "Dzialka",
                newName: "IX_Dzialka_KonserwZabytkowSloId");

            migrationBuilder.AddColumn<int>(
                name: "KonserwPrzyrodySloId",
                table: "Dzialka",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KonserwPrzyrodySlo",
                columns: table => new
                {
                    KonserwPrzyrodySloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonserwPrzyrodySlo", x => x.KonserwPrzyrodySloId);
                });

            migrationBuilder.CreateTable(
                name: "KonserwZabytkowSlo",
                columns: table => new
                {
                    KonserwZabytkowSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonserwZabytkowSlo", x => x.KonserwZabytkowSloId);
                });

            migrationBuilder.CreateTable(
                name: "PrzedstawicielSlo",
                columns: table => new
                {
                    PrzedstawicielSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrzedstawicielSlo", x => x.PrzedstawicielSloId);
                });

            migrationBuilder.InsertData(
                table: "KonserwPrzyrodySlo",
                columns: new[] { "KonserwPrzyrodySloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "Nie" },
                    { 3, "Tak" }
                });

            migrationBuilder.InsertData(
                table: "KonserwZabytkowSlo",
                columns: new[] { "KonserwZabytkowSloId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "-" },
                    { 2, "rejestr zabytków" },
                    { 3, "Gminna Ewidencja Zabytków" },
                    { 4, "MPZP" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dzialka_KonserwPrzyrodySloId",
                table: "Dzialka",
                column: "KonserwPrzyrodySloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dzialka_KonserwPrzyrodySlo_KonserwPrzyrodySloId",
                table: "Dzialka",
                column: "KonserwPrzyrodySloId",
                principalTable: "KonserwPrzyrodySlo",
                principalColumn: "KonserwPrzyrodySloId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dzialka_KonserwZabytkowSlo_KonserwZabytkowSloId",
                table: "Dzialka",
                column: "KonserwZabytkowSloId",
                principalTable: "KonserwZabytkowSlo",
                principalColumn: "KonserwZabytkowSloId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dzialka_KonserwPrzyrodySlo_KonserwPrzyrodySloId",
                table: "Dzialka");

            migrationBuilder.DropForeignKey(
                name: "FK_Dzialka_KonserwZabytkowSlo_KonserwZabytkowSloId",
                table: "Dzialka");

            migrationBuilder.DropTable(
                name: "KonserwPrzyrodySlo");

            migrationBuilder.DropTable(
                name: "KonserwZabytkowSlo");

            migrationBuilder.DropTable(
                name: "PrzedstawicielSlo");

            migrationBuilder.DropIndex(
                name: "IX_Dzialka_KonserwPrzyrodySloId",
                table: "Dzialka");

            migrationBuilder.DropColumn(
                name: "KonserwPrzyrodySloId",
                table: "Dzialka");

            migrationBuilder.RenameColumn(
                name: "KonserwZabytkowSloId",
                table: "Dzialka",
                newName: "NadzorKonserwSloId");

            migrationBuilder.RenameIndex(
                name: "IX_Dzialka_KonserwZabytkowSloId",
                table: "Dzialka",
                newName: "IX_Dzialka_NadzorKonserwSloId");

            migrationBuilder.CreateTable(
                name: "NadzorKonserwSlo",
                columns: table => new
                {
                    NadzorKonserwSloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NadzorKonserwSlo", x => x.NadzorKonserwSloId);
                });

            migrationBuilder.InsertData(
                table: "NadzorKonserwSlo",
                columns: new[] { "NadzorKonserwSloId", "Nazwa" },
                values: new object[] { 1, "-" });

            migrationBuilder.InsertData(
                table: "NadzorKonserwSlo",
                columns: new[] { "NadzorKonserwSloId", "Nazwa" },
                values: new object[] { 2, "Nie" });

            migrationBuilder.InsertData(
                table: "NadzorKonserwSlo",
                columns: new[] { "NadzorKonserwSloId", "Nazwa" },
                values: new object[] { 3, "Tak" });

            migrationBuilder.AddForeignKey(
                name: "FK_Dzialka_NadzorKonserwSlo_NadzorKonserwSloId",
                table: "Dzialka",
                column: "NadzorKonserwSloId",
                principalTable: "NadzorKonserwSlo",
                principalColumn: "NadzorKonserwSloId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
