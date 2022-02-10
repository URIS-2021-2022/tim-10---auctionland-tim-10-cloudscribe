using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcela.Migrations
{
    public partial class ParcelaThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parcela",
                keyColumn: "ParcelaId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "OblikSvojine", "ZasticenZonaStvarnoStanje" },
                values: new object[] { "OS", "ZZSS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parcela",
                keyColumn: "ParcelaId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "OblikSvojine", "ZasticenZonaStvarnoStanje" },
                values: new object[] { null, null });
        }
    }
}
