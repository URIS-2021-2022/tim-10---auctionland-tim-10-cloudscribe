using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcela.Migrations
{
    public partial class ParcelaSecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parcela",
                columns: new[] { "ParcelaId", "BrojListaNepokretnosti", "BrojParcele", "KatastarskaOpstina", "Klasa", "KlasaStvarnoStanje", "KorisnikId", "Kultura", "KulturaStvarnoStanje", "OBradivostStvarnoStanje", "OblikSvojine", "Obradivost", "Odvodnjavanje", "OdvodnjavanjeStvarnoStanje", "Povrsina", "ZasticenZonaStvarnoStanje", "ZasticenaZona" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "BLN", "1", "Indjija", "Klasa", "KSS", new Guid("6a411c13-a295-48f7-8dbd-67596c3974c0"), "K", "KSS", "OSS", null, "O", "O", "OSS", 100, null, "Z" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parcela",
                keyColumn: "ParcelaId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"));
        }
    }
}
