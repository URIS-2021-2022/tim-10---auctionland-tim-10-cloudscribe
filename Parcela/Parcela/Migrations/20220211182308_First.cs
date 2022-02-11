using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcela.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parcela",
                columns: table => new
                {
                    ParcelaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Povrsina = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojParcele = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KatastarskaOpstina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojListaNepokretnosti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kultura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Klasa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obradivost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZasticenaZona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OblikSvojine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odvodnjavanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KulturaStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlasaStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OBradivostStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZasticenZonaStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdvodnjavanjeStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.ParcelaId);
                });

            migrationBuilder.CreateTable(
                name: "DeoParceleEntity",
                columns: table => new
                {
                    DeoParceleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Povrsina = table.Column<int>(type: "int", nullable: false),
                    RedniBroj = table.Column<int>(type: "int", nullable: false),
                    Dodeljena = table.Column<bool>(type: "bit", nullable: false),
                    ParcelaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeoParceleEntity", x => x.DeoParceleId);
                    table.ForeignKey(
                        name: "FK_DeoParceleEntity_Parcela_ParcelaId",
                        column: x => x.ParcelaId,
                        principalTable: "Parcela",
                        principalColumn: "ParcelaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parcela",
                columns: new[] { "ParcelaId", "BrojListaNepokretnosti", "BrojParcele", "KatastarskaOpstina", "Klasa", "KlasaStvarnoStanje", "KorisnikId", "Kultura", "KulturaStvarnoStanje", "OBradivostStvarnoStanje", "OblikSvojine", "Obradivost", "Odvodnjavanje", "OdvodnjavanjeStvarnoStanje", "Povrsina", "ZasticenZonaStvarnoStanje", "ZasticenaZona" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "BLN", "1", "Indjija", "Klasa", "KSS", new Guid("6a411c13-a295-48f7-8dbd-67596c3974c0"), "K", "KSS", "OSS", "OS", "O", "O", "OSS", 100, "ZZSS", "Z" });

            migrationBuilder.InsertData(
                table: "DeoParceleEntity",
                columns: new[] { "DeoParceleId", "Dodeljena", "ParcelaId", "Povrsina", "RedniBroj" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), false, new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 100, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DeoParceleEntity_ParcelaId",
                table: "DeoParceleEntity",
                column: "ParcelaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeoParceleEntity");

            migrationBuilder.DropTable(
                name: "Parcela");
        }
    }
}
