using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OglasService.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oglasi",
                columns: table => new
                {
                    OglasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TekstOglasa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SluzbeniListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglasi", x => x.OglasId);
                });

            migrationBuilder.CreateTable(
                name: "SluzbeniListovi",
                columns: table => new
                {
                    SluzbeniListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Opstina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojSluzbenogLista = table.Column<int>(type: "int", nullable: false),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SluzbeniListovi", x => x.SluzbeniListId);
                });

            migrationBuilder.InsertData(
                table: "Oglasi",
                columns: new[] { "OglasId", "SluzbeniListId", "TekstOglasa" },
                values: new object[,]
                {
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c397444"), new Guid("6a411c13-a195-48f7-8dbd-67596c397412"), "Javni oglas za davanje u zakup poljoprivrednog zemljišta u državnoj svojini" },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c397498"), new Guid("6a411c13-a195-48f7-8dbd-67596c397411"), "Javni oglas za davanje u zakup poljoprivrednog zemljišta u državnoj svojini" }
                });

            migrationBuilder.InsertData(
                table: "SluzbeniListovi",
                columns: new[] { "SluzbeniListId", "BrojSluzbenogLista", "DatumIzdavanja", "Opstina" },
                values: new object[,]
                {
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c397412"), 12, new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Novi Beograd" },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c397411"), 5, new DateTime(2021, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Novi Sad" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oglasi");

            migrationBuilder.DropTable(
                name: "SluzbeniListovi");
        }
    }
}
