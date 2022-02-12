using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcela.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KatastarskaOpstina",
                columns: table => new
                {
                    KatastarskaOpstinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImeKatastarskeOpstine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatastarskaOpstina", x => x.KatastarskaOpstinaId);
                });

            migrationBuilder.InsertData(
                table: "KatastarskaOpstina",
                columns: new[] { "KatastarskaOpstinaId", "ImeKatastarskeOpstine" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Mladenburg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KatastarskaOpstina");
        }
    }
}
