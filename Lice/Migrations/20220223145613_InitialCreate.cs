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
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    faks = table.Column<int>(type: "int", nullable: true),
                    maticniBroj = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                values: new object[,]
                {
                    { new Guid("26797103-3a18-4750-9f27-33416e6e30d4"), "Vlasnik sistema za navodnjavanje" },
                    { new Guid("00cdf29d-e0d0-4207-87b2-16486eda55ab"), ". Vlasnik zemljišta koje se graniči sa zemljištem koje se daje u zakup" },
                    { new Guid("08062c01-9bfd-4c85-8501-f5ab8c026f2a"), "Poljoprivrednik koji je upisan u Registar" },
                    { new Guid("7c9752fc-86a9-41e6-b4b8-c22b1c9a6ab9"), "Vlasnik zemljišta koje je najbliže zemljištu koje se daje u zakup" }
                });

            migrationBuilder.InsertData(
                table: "Lica",
                columns: new[] { "liceId", "Discriminator", "JMBG", "brojRacuna", "brojTelefona1", "brojTelefona2", "email", "ime", "prezime", "prioritetId" },
                values: new object[,]
                {
                    { new Guid("65f1a8da-433f-42d1-82f6-6b771ddde854"), "FizickoLiceEntity", "2506995745621", "80045875687", "062586654", "061582236", "mmarkovic@gmail.com", "Marko", "Marković", new Guid("26797103-3a18-4750-9f27-33416e6e30d4") },
                    { new Guid("8bb61e16-0c5c-4ea1-8e2b-9c48719c7aab"), "FizickoLiceEntity", "1407994556214", "8008465687", "0665826695", "0656258965", "nnikolic@gmail.com", "Nikola", "Nikolić", new Guid("26797103-3a18-4750-9f27-33416e6e30d4") }
                });

            migrationBuilder.InsertData(
                table: "Lica",
                columns: new[] { "liceId", "Discriminator", "brojRacuna", "brojTelefona1", "brojTelefona2", "email", "faks", "maticniBroj", "naziv", "prioritetId" },
                values: new object[,]
                {
                    { new Guid("529351b3-2c8c-41c6-abba-aa5feb564d06"), "PravnoLiceEntity", "800458757", "0695784105", "0625486214", "masterplast@gmail.com", 24601785, "25485674", "Masterplast", new Guid("26797103-3a18-4750-9f27-33416e6e30d4") },
                    { new Guid("d05f182d-7ef0-484b-9045-3f0451605cdb"), "PravnoLiceEntity", "8004574587", "0645289956", "0625482685", "pannonglobal@gmail.com", 24601785, "75486254", "Pannonglobal", new Guid("26797103-3a18-4750-9f27-33416e6e30d4") }
                });

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
