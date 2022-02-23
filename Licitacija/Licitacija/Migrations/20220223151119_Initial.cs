using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Licitacija.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licitacija",
                columns: table => new
                {
                    licitacijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brojLicitacije = table.Column<int>(type: "int", nullable: false),
                    godinaLicitacije = table.Column<int>(type: "int", nullable: false),
                    datumRaspisivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ogranicenje = table.Column<int>(type: "int", nullable: false),
                    krugLicitacije = table.Column<int>(type: "int", nullable: false),
                    rokZaPrijave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    javnoNadmetanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licitacija", x => x.licitacijaId);
                });

            migrationBuilder.InsertData(
                table: "Licitacija",
                columns: new[] { "licitacijaId", "brojLicitacije", "datumRaspisivanja", "godinaLicitacije", "javnoNadmetanjeId", "krugLicitacije", "ogranicenje", "rokZaPrijave" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 1, new DateTime(2021, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2021, new Guid("6a411c13-a195-48f7-8dbd-67596c3973c0"), 1, 0, new DateTime(2021, 7, 1, 23, 59, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Licitacija",
                columns: new[] { "licitacijaId", "brojLicitacije", "datumRaspisivanja", "godinaLicitacije", "javnoNadmetanjeId", "krugLicitacije", "ogranicenje", "rokZaPrijave" },
                values: new object[] { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"), 2, new DateTime(2021, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 2022, new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 1, 1, new DateTime(2021, 11, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licitacija");
        }
    }
}
