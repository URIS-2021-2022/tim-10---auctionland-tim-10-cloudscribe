using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiciterService.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zastupnici",
                columns: table => new
                {
                    ZastupnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Jmbg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojPasosa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NazivDrzave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTable = table.Column<int>(type: "int", nullable: false),
                    AdresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zastupnici", x => x.ZastupnikId);
                });

            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumPocetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumPrestankaZabrane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzinaTrajanjaZabrane = table.Column<int>(type: "int", nullable: false),
                    ImaZabranu = table.Column<bool>(type: "bit", nullable: false),
                    OstvarenaPovrsina = table.Column<int>(type: "int", nullable: false),
                    ZastupnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.KupacId);
                    table.ForeignKey(
                        name: "FK_Kupci_Zastupnici_ZastupnikId",
                        column: x => x.ZastupnikId,
                        principalTable: "Zastupnici",
                        principalColumn: "ZastupnikId");
                });

            migrationBuilder.CreateTable(
                name: "Liciteri",
                columns: table => new
                {
                    LiciterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZastupnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    liceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liciteri", x => x.LiciterId);
                    table.ForeignKey(
                        name: "FK_Liciteri_Kupci_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupci",
                        principalColumn: "KupacId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Liciteri_Zastupnici_ZastupnikId",
                        column: x => x.ZastupnikId,
                        principalTable: "Zastupnici",
                        principalColumn: "ZastupnikId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Zastupnici",
                columns: new[] { "ZastupnikId", "AdresaId", "BrojPasosa", "BrojTable", "Jmbg", "KupacId", "NazivDrzave" },
                values: new object[] { new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a66"), new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "987654321", 255, "1635889629999", new Guid("32cd906d-8bab-457c-ade2-fbc4ba523077"), "Srbija" });

            migrationBuilder.InsertData(
                table: "Zastupnici",
                columns: new[] { "ZastupnikId", "AdresaId", "BrojPasosa", "BrojTable", "Jmbg", "KupacId", "NazivDrzave" },
                values: new object[] { new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a52"), new Guid("32cd906d-8bab-457c-ade2-fbc4ba523029"), "123456789", 365, "5896634547231", new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a36"), "Srbija" });

            migrationBuilder.InsertData(
                table: "Kupci",
                columns: new[] { "KupacId", "DatumPocetkaZabrane", "DatumPrestankaZabrane", "DuzinaTrajanjaZabrane", "ImaZabranu", "OstvarenaPovrsina", "ZastupnikId" },
                values: new object[] { new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a36"), new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 365, true, 1500000, new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a52") });

            migrationBuilder.InsertData(
                table: "Kupci",
                columns: new[] { "KupacId", "DatumPocetkaZabrane", "DatumPrestankaZabrane", "DuzinaTrajanjaZabrane", "ImaZabranu", "OstvarenaPovrsina", "ZastupnikId" },
                values: new object[] { new Guid("32cd906d-8bab-457c-ade2-fbc4ba523055"), new DateTime(2021, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 365, true, 15500, new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a52") });

            migrationBuilder.InsertData(
                table: "Liciteri",
                columns: new[] { "LiciterId", "KupacId", "ZastupnikId", "liceId" },
                values: new object[] { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"), new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a36"), new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a52"), new Guid("8bb61e16-0c5c-4ea1-8e2b-9c48719c7aab") });

            migrationBuilder.InsertData(
                table: "Liciteri",
                columns: new[] { "LiciterId", "KupacId", "ZastupnikId", "liceId" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), new Guid("32cd906d-8bab-457c-ade2-fbc4ba523055"), new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a66"), new Guid("d05f182d-7ef0-484b-9045-3f0451605cdb") });

            migrationBuilder.CreateIndex(
                name: "IX_Kupci_ZastupnikId",
                table: "Kupci",
                column: "ZastupnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Liciteri_KupacId",
                table: "Liciteri",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_Liciteri_ZastupnikId",
                table: "Liciteri",
                column: "ZastupnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Liciteri");

            migrationBuilder.DropTable(
                name: "Kupci");

            migrationBuilder.DropTable(
                name: "Zastupnici");
        }
    }
}
