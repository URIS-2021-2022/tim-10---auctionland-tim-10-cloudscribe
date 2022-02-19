using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiciterService.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    LiciterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImeLicitera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrezimeLicitera = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Jmbg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojPasosa = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                columns: new[] { "KupacId", "DatumPocetkaZabrane", "DatumPrestankaZabrane", "DuzinaTrajanjaZabrane", "ImaZabranu", "OstvarenaPovrsina" },
                values: new object[,]
                {
                    { new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a36"), new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 365, true, 1500000 },
                    { new Guid("32cd906d-8bab-457c-ade2-fbc4ba523029"), new DateTime(2021, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 365, true, 15500 }
                });

            migrationBuilder.InsertData(
                table: "Liciteri",
                columns: new[] { "LiciterId", "ImeLicitera", "PrezimeLicitera" },
                values: new object[,]
                {
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Nikola", "Tesla" },
                    { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"), "Mihajlo", "Pupin" }
                });

            migrationBuilder.InsertData(
                table: "Zastupnici",
                columns: new[] { "ZastupnikId", "Adresa", "BrojPasosa", "BrojTable", "Jmbg", "KupacId", "NazivDrzave" },
                values: new object[] { new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a52"), null, "123456789", 365, "5896634547231", new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a36"), "Srbija" });

            migrationBuilder.InsertData(
                table: "Zastupnici",
                columns: new[] { "ZastupnikId", "Adresa", "BrojPasosa", "BrojTable", "Jmbg", "KupacId", "NazivDrzave" },
                values: new object[] { new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a66"), null, "987654321", 255, "1635889629999", new Guid("32cd906d-8bab-457c-ade2-fbc4ba523029"), "Srbija" });

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
