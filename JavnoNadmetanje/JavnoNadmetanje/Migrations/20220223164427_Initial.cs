using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JavnoNadmetanje.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etapa",
                columns: table => new
                {
                    etapaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brojEtape = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapa", x => x.etapaID);
                });

            migrationBuilder.CreateTable(
                name: "KorakCene",
                columns: table => new
                {
                    korakCeneID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brojKoraka = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorakCene", x => x.korakCeneID);
                });

            migrationBuilder.CreateTable(
                name: "JavnoNadmetanje",
                columns: table => new
                {
                    javnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vremePocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vremeKraja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pocetnaCena = table.Column<int>(type: "int", nullable: false),
                    izuzeto = table.Column<bool>(type: "bit", nullable: false),
                    tip = table.Column<int>(type: "int", nullable: false),
                    izlicitiranaCena = table.Column<int>(type: "int", nullable: false),
                    katastarskaOpstina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    periodZakupa = table.Column<int>(type: "int", nullable: false),
                    brojUcesnika = table.Column<int>(type: "int", nullable: false),
                    dopunaDepozita = table.Column<int>(type: "int", nullable: false),
                    krug = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    etapaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    adresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parcelaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    liciterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojJavneLicitacije = table.Column<int>(type: "int", nullable: true),
                    opisJavneLicitacije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korakCeneID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    brojJZOP = table.Column<int>(type: "int", nullable: true),
                    opisJZOP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnoNadmetanje", x => x.javnoNadmetanjeID);
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanje_Etapa_etapaID",
                        column: x => x.etapaID,
                        principalTable: "Etapa",
                        principalColumn: "etapaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanje_KorakCene_korakCeneID",
                        column: x => x.korakCeneID,
                        principalTable: "KorakCene",
                        principalColumn: "korakCeneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Etapa",
                columns: new[] { "etapaID", "brojEtape" },
                values: new object[,]
                {
                    { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e968b"), 1 },
                    { new Guid("1c7ea607-8ddb-493a-87fa-4bf5873e968b"), 2 }
                });

            migrationBuilder.InsertData(
                table: "KorakCene",
                columns: new[] { "korakCeneID", "brojKoraka" },
                values: new object[,]
                {
                    { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e961b"), 1 },
                    { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e938b"), 2 }
                });

            migrationBuilder.InsertData(
                table: "JavnoNadmetanje",
                columns: new[] { "javnoNadmetanjeID", "Discriminator", "adresaId", "brojJZOP", "brojUcesnika", "datum", "dopunaDepozita", "etapaID", "izlicitiranaCena", "izuzeto", "katastarskaOpstina", "krug", "liciterId", "opisJZOP", "parcelaId", "periodZakupa", "pocetnaCena", "status", "tip", "vremeKraja", "vremePocetka" },
                values: new object[,]
                {
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3573c0"), "JzopEntity", new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 2, 15, new DateTime(2021, 6, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 5000, new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e968b"), 205000, false, "Novi Grad", 1, new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Drugi tip javnog nadmetanja", new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 5, 55000, "Prvi krug", 1, new DateTime(2021, 6, 11, 13, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c4973c0"), "JzopEntity", new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 2, 45, new DateTime(2021, 6, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 5000, new Guid("1c7ea607-8ddb-493a-87fa-4bf5873e968b"), 205000, false, "Novi Grad", 1, new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Drugi tip javnog nadmetanja", new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 5, 55000, "Prvi krug", 1, new DateTime(2021, 6, 11, 13, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JavnoNadmetanje",
                columns: new[] { "javnoNadmetanjeID", "Discriminator", "adresaId", "brojJavneLicitacije", "brojUcesnika", "datum", "dopunaDepozita", "etapaID", "izlicitiranaCena", "izuzeto", "katastarskaOpstina", "korakCeneID", "krug", "liciterId", "opisJavneLicitacije", "parcelaId", "periodZakupa", "pocetnaCena", "status", "tip", "vremeKraja", "vremePocetka" },
                values: new object[,]
                {
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3973c0"), "JavnaLicitacijaEntity", new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 1, 15, new DateTime(2021, 6, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 5000, new Guid("1c7ea607-8ddb-493a-87fa-4bf5873e968b"), 205000, false, "Novi Grad", new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e961b"), 1, new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Prvi tip javnog nadmetanja", new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 5, 55000, "Prvi krug", 1, new DateTime(2021, 6, 11, 13, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "JavnaLicitacijaEntity", new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 2, 25, new DateTime(2021, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5000, new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e968b"), 200000, false, "Novi Grad", new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e938b"), 1, new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Prvi tip javnog nadmetanja", new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 5, 50000, "Prvi krug", 1, new DateTime(2021, 6, 1, 13, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JavnoNadmetanje_etapaID",
                table: "JavnoNadmetanje",
                column: "etapaID");

            migrationBuilder.CreateIndex(
                name: "IX_JavnoNadmetanje_korakCeneID",
                table: "JavnoNadmetanje",
                column: "korakCeneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JavnoNadmetanje");

            migrationBuilder.DropTable(
                name: "Etapa");

            migrationBuilder.DropTable(
                name: "KorakCene");
        }
    }
}
