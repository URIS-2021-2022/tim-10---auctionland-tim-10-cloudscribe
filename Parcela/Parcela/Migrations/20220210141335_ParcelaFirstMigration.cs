using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcela.Migrations
{
    public partial class ParcelaFirstMigration : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcela");
        }
    }
}
