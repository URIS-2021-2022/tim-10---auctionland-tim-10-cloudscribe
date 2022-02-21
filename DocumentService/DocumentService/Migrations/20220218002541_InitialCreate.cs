using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    DokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZavodniBroj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NazivDokumenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDonosenjaOdluke = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sablon = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.DokumentID);
                });

            migrationBuilder.CreateTable(
                name: "tipDokumenta",
                columns: table => new
                {
                    TipDokumentaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipDokumenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDokumenta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipDokumenta", x => x.TipDokumentaID);
                });

            migrationBuilder.InsertData(
                table: "Dokument",
                columns: new[] { "DokumentID", "Datum", "DatumDonosenjaOdluke", "NazivDokumenta", "Sablon", "ZavodniBroj" },
                values: new object[,]
                {
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3975a3"), new DateTime(2020, 12, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), "Dokument1", true, "1" },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3972b2"), new DateTime(2019, 6, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "Dokument2", false, "2" }
                });

            migrationBuilder.InsertData(
                table: "tipDokumenta",
                columns: new[] { "TipDokumentaID", "StatusDokumenta", "TipDokumenta" },
                values: new object[,]
                {
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3975b2"), "Usvojen", "Sablon" },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3975b1"), "Odbijen", "Negenericki" },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3974a2"), "Otvoren", "Sablon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "tipDokumenta");
        }
    }
}
