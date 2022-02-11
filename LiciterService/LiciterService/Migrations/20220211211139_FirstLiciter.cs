using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiciterService.Migrations
{
    public partial class FirstLiciter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImeKupca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrezimeKupca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumPocetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumPrestankaZabrane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzinaTrajanjaZabrane = table.Column<int>(type: "int", nullable: false),
                    ImaZabranu = table.Column<bool>(type: "bit", nullable: false),
                    OstvarenaPovrsina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.KupacId);
                });

            migrationBuilder.CreateTable(
                name: "Liciteri",
                columns: table => new
                {
                    LiciterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liciteri", x => x.LiciterId);
                });

            migrationBuilder.CreateTable(
                name: "Zastupnici",
                columns: table => new
                {
                    ZastupnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImeZastupnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrezimeZastupnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jmbg = table.Column<int>(type: "int", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NazivDrzave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTable = table.Column<int>(type: "int", nullable: false),
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zastupnici", x => x.ZastupnikId);
                    table.ForeignKey(
                        name: "FK_Zastupnici_Kupci_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupci",
                        principalColumn: "KupacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kupci",
                columns: new[] { "KupacId", "DatumPocetkaZabrane", "DatumPrestankaZabrane", "DuzinaTrajanjaZabrane", "ImaZabranu", "ImeKupca", "OstvarenaPovrsina", "PrezimeKupca" },
                values: new object[,]
                {
                    { new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a36"), new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 365, true, "Maksim", 1500000, "Gorki" },
                    { new Guid("32cd906d-8bab-457c-ade2-fbc4ba523029"), new DateTime(2021, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 365, true, "Dzejn", 15500, "Ostin" }
                });

            migrationBuilder.InsertData(
                table: "Liciteri",
                column: "LiciterId",
                values: new object[]
                {
                    new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b")
                });

            migrationBuilder.InsertData(
                table: "Zastupnici",
                columns: new[] { "ZastupnikId", "Adresa", "BrojTable", "ImeZastupnika", "Jmbg", "KupacId", "NazivDrzave", "PrezimeZastupnika" },
                values: new object[] { new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a52"), "Narodnog Fronta 13", 365, "Petar", 58966345, new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a36"), "Srbija", "Petrovic" });

            migrationBuilder.InsertData(
                table: "Zastupnici",
                columns: new[] { "ZastupnikId", "Adresa", "BrojTable", "ImeZastupnika", "Jmbg", "KupacId", "NazivDrzave", "PrezimeZastupnika" },
                values: new object[] { new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a66"), "Beogradska 25", 255, "Novak", 163588962, new Guid("32cd906d-8bab-457c-ade2-fbc4ba523029"), "Srbija", "Djokovic" });

            migrationBuilder.CreateIndex(
                name: "IX_Zastupnici_KupacId",
                table: "Zastupnici",
                column: "KupacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Liciteri");

            migrationBuilder.DropTable(
                name: "Zastupnici");

            migrationBuilder.DropTable(
                name: "Kupci");
        }
    }
}
