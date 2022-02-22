using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Korisnik.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komisije",
                columns: table => new
                {
                    KomisijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komisije", x => x.KomisijaId);
                });

            migrationBuilder.CreateTable(
                name: "Tipovi",
                columns: table => new
                {
                    TipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipovi", x => x.TipId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KorisnikIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikPrezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikKorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikLozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KomisijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikId);
                    table.ForeignKey(
                        name: "FK_Korisnici_Tipovi_TipId",
                        column: x => x.TipId,
                        principalTable: "Tipovi",
                        principalColumn: "TipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Komisije",
                columns: new[] { "KomisijaId", "Opis" },
                values: new object[] { new Guid("617b029a-a949-44d2-b7d2-366a9058e016"), null });

            migrationBuilder.InsertData(
                table: "Tipovi",
                columns: new[] { "TipId", "TipKorisnika" },
                values: new object[,]
                {
                    { new Guid("bda80420-444e-40d4-a97f-2d8be0df7c0c"), "Operater" },
                    { new Guid("719cbcae-ba05-4bdf-b0f8-636d79b70180"), "Tehnicki sekretar" },
                    { new Guid("4915ab80-5233-45a7-a7d2-b8c636fa934d"), "Superuser" },
                    { new Guid("f4ae8300-84cd-488f-90c7-d5b1d871bd9e"), "Operator nadmetanja" },
                    { new Guid("d2a484a7-e975-43c6-9604-21ac9459456f"), "Administrator" },
                    { new Guid("61643c5a-da3e-4388-86f8-4e0934de0e86"), "Licitant" },
                    { new Guid("9ddfc708-5a68-40ba-b76c-95b27e63ba9a"), "Menadzer" },
                    { new Guid("10d3f482-9538-448f-9399-bbbade1bc504"), "Prva komisija" }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikId", "KomisijaId", "KorisnikIme", "KorisnikKorisnickoIme", "KorisnikLozinka", "KorisnikPrezime", "Salt", "TipId" },
                values: new object[] { new Guid("850da794-6460-424d-bd01-731e2f54a8c8"), new Guid("617b029a-a949-44d2-b7d2-366a9058e016"), "Teodora", "teajovanovic92", "pera", "Jovanovic", null, new Guid("10d3f482-9538-448f-9399-bbbade1bc504") });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_TipId",
                table: "Korisnici",
                column: "TipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komisije");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Tipovi");
        }
    }
}
