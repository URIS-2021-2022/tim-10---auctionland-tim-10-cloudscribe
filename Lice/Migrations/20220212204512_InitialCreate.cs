using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lica",
                columns: table => new
                {
                    liceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brojTelefona1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brojTelefona2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    faks = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lica", x => x.liceId);
                });

            migrationBuilder.InsertData(
                table: "Lica",
                columns: new[] { "liceId", "Discriminator", "brojRacuna", "brojTelefona1", "brojTelefona2", "email", "ime", "prezime" },
                values: new object[] { new Guid("71b99b68-8e8f-4cc3-b8d2-d6badc704221"), "FizickoLiceEntity", "brRac1", "123456", "789456", "email1", "Ime1", "Prezime1" });

            migrationBuilder.InsertData(
                table: "Lica",
                columns: new[] { "liceId", "Discriminator", "brojRacuna", "brojTelefona1", "brojTelefona2", "email", "faks", "naziv" },
                values: new object[] { new Guid("25499084-4d50-412b-9640-1ab07af33d4d"), "PravnoLiceEntity", "brRac2", "456123", "45214", "email2", 125, "PravnoLice1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lica");
        }
    }
}
