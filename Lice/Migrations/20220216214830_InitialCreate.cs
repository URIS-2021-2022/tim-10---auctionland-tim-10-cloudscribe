using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prioriteti",
                columns: table => new
                {
                    prioritetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    opisPrioriteta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioriteti", x => x.prioritetId);
                });

            migrationBuilder.CreateTable(
                name: "Lica",
                columns: table => new
                {
                    liceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brojTelefona1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brojTelefona2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prioritetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    faks = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lica", x => x.liceId);
                    table.ForeignKey(
                        name: "FK_Lica_Prioriteti_prioritetId",
                        column: x => x.prioritetId,
                        principalTable: "Prioriteti",
                        principalColumn: "prioritetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Prioriteti",
                columns: new[] { "prioritetId", "opisPrioriteta" },
                values: new object[] { new Guid("26797103-3a18-4750-9f27-33416e6e30d4"), "Vlasnik sistema za navodnjavanje" });

            migrationBuilder.InsertData(
                table: "Lica",
                columns: new[] { "liceId", "Discriminator", "brojRacuna", "brojTelefona1", "brojTelefona2", "email", "ime", "prezime", "prioritetId" },
                values: new object[] { new Guid("71b99b68-8e8f-4cc3-b8d2-d6badc704221"), "FizickoLiceEntity", "brRac1", "123456", "789456", "email1", "Ime1", "Prezime1", new Guid("26797103-3a18-4750-9f27-33416e6e30d4") });

            migrationBuilder.InsertData(
                table: "Lica",
                columns: new[] { "liceId", "Discriminator", "brojRacuna", "brojTelefona1", "brojTelefona2", "email", "faks", "naziv", "prioritetId" },
                values: new object[] { new Guid("25499084-4d50-412b-9640-1ab07af33d4d"), "PravnoLiceEntity", "brRac2", "456123", "45214", "email2", 125, "PravnoLice1", new Guid("26797103-3a18-4750-9f27-33416e6e30d4") });

            migrationBuilder.CreateIndex(
                name: "IX_Lica_prioritetId",
                table: "Lica",
                column: "prioritetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lica");

            migrationBuilder.DropTable(
                name: "Prioriteti");
        }
    }
}
