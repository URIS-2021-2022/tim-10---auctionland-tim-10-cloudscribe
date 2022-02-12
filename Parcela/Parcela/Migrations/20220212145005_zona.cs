using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcela.Migrations
{
    public partial class zona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZasticenaZona",
                columns: table => new
                {
                    ZasticenZonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojZone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZasticenaZona", x => x.ZasticenZonaId);
                });

            migrationBuilder.InsertData(
                table: "ZasticenaZona",
                columns: new[] { "ZasticenZonaId", "BrojZone" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZasticenaZona");
        }
    }
}
