using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adresa.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzave",
                columns: table => new
                {
                    DrzavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivDrzave = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzave", x => x.DrzavaId);
                });

            migrationBuilder.CreateTable(
                name: "Adrese",
                columns: table => new
                {
                    AdresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Broj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false),
                    DrzavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adrese", x => x.AdresaId);
                    table.ForeignKey(
                        name: "FK_Adrese_Drzave_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzave",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "NazivDrzave" },
                values: new object[] { new Guid("170960f3-f8e0-4614-aff2-653aadf5c720"), "Drzava1" });

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaId", "NazivDrzave" },
                values: new object[] { new Guid("c8a9ffbc-db56-46ff-a54a-948c91550189"), "Drzava2" });

            migrationBuilder.InsertData(
                table: "Adrese",
                columns: new[] { "AdresaId", "Broj", "DrzavaId", "Mesto", "PostanskiBroj", "Ulica" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "1", new Guid("170960f3-f8e0-4614-aff2-653aadf5c720"), "Mesto1", 123, "Ulica1" });

            migrationBuilder.InsertData(
                table: "Adrese",
                columns: new[] { "AdresaId", "Broj", "DrzavaId", "Mesto", "PostanskiBroj", "Ulica" },
                values: new object[] { new Guid("32cd906d-8bab-457c-ade2-fbc4ba523029"), "2", new Guid("c8a9ffbc-db56-46ff-a54a-948c91550189"), "Mesto2", 123456, "Ulica2" });

            migrationBuilder.CreateIndex(
                name: "IX_Adrese_DrzavaId",
                table: "Adrese",
                column: "DrzavaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adrese");

            migrationBuilder.DropTable(
                name: "Drzave");
        }
    }
}
