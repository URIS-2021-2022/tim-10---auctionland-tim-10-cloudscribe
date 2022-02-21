using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcela.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KatastarskaOpstina",
                columns: table => new
                {
                    KatastarskaOpstinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImeKatastarskeOpstine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatastarskaOpstina", x => x.KatastarskaOpstinaId);
                });

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

            migrationBuilder.CreateTable(
                name: "Parcela",
                columns: table => new
                {
                    ParcelaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Povrsina = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojParcele = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojListaNepokretnosti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kultura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Klasa = table.Column<int>(type: "int", nullable: false),
                    Obradivost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZasticenaZonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OblikSvojine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odvodnjavanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KatastarskaOpstinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeoParceleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.ParcelaId);
                    table.ForeignKey(
                        name: "FK_Parcela_KatastarskaOpstina_KatastarskaOpstinaId",
                        column: x => x.KatastarskaOpstinaId,
                        principalTable: "KatastarskaOpstina",
                        principalColumn: "KatastarskaOpstinaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcela_ZasticenaZona_ZasticenaZonaId",
                        column: x => x.ZasticenaZonaId,
                        principalTable: "ZasticenaZona",
                        principalColumn: "ZasticenZonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeoParceleEntity",
                columns: table => new
                {
                    DeoParceleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Povrsina = table.Column<int>(type: "int", nullable: false),
                    RedniBroj = table.Column<int>(type: "int", nullable: false),
                    Dodeljena = table.Column<bool>(type: "bit", nullable: false),
                    ParcelaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeoParceleEntity", x => x.DeoParceleId);
                    table.ForeignKey(
                        name: "FK_DeoParceleEntity_Parcela_ParcelaId",
                        column: x => x.ParcelaId,
                        principalTable: "Parcela",
                        principalColumn: "ParcelaId");
                });

            migrationBuilder.InsertData(
                table: "KatastarskaOpstina",
                columns: new[] { "KatastarskaOpstinaId", "ImeKatastarskeOpstine" },
                values: new object[,]
                {
                    { new Guid("1807a208-3bca-49de-a159-293e14393909"), "Cantavir" },
                    { new Guid("b438a02a-d1b7-479a-85ce-65fd6d9601aa"), "Backi Vinogradi" },
                    { new Guid("eb74f014-1169-44fc-bf89-0abe0a0db7d7"), "Bikovo" },
                    { new Guid("7242001a-b2e2-4513-8117-d797dfcf417b"), "Bajmok" },
                    { new Guid("c763afda-7346-4fca-82e1-2e5d6416fb71"), "Djudjin" },
                    { new Guid("2736f15a-8ead-4c5e-8eff-2b9d7add73e0"), "Zednik" },
                    { new Guid("6e7d325e-5f90-4d96-8277-0c924d5e0223"), "Tavankut" },
                    { new Guid("529a1c5b-e0aa-4561-8298-756ca2d6c000"), "Donji Grad" },
                    { new Guid("779341c2-3b97-4598-9329-09bc0c7dd3a4"), "Stari Grad" },
                    { new Guid("f5cc25e4-ee78-4c8c-9986-1d80cf4bc225"), "Novi Grad" },
                    { new Guid("d3dcc333-2106-4f1a-8ed0-255be4d9ebb9"), "Palic" }
                });

            migrationBuilder.InsertData(
                table: "ZasticenaZona",
                columns: new[] { "ZasticenZonaId", "BrojZone" },
                values: new object[,]
                {
                    { new Guid("af2d6f85-d341-4433-8f21-3f28f816a79e"), 1 },
                    { new Guid("66e5ce4a-453b-4d21-91d6-c533617778d3"), 2 },
                    { new Guid("2b605587-1ccd-4b2f-b988-957724c04ffa"), 3 },
                    { new Guid("b5ca4235-c02c-4020-a6a6-cb7146ca5fb8"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Parcela",
                columns: new[] { "ParcelaId", "BrojListaNepokretnosti", "BrojParcele", "DeoParceleId", "KatastarskaOpstinaId", "Klasa", "KorisnikId", "Kultura", "OblikSvojine", "Obradivost", "Odvodnjavanje", "Povrsina", "ZasticenaZonaId" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "5", "1", new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), new Guid("1807a208-3bca-49de-a159-293e14393909"), 1, new Guid("6a411c13-a295-48f7-8dbd-67596c3974c0"), "Njive", "Drzavno", "Obradivo", "Podvnodno", 100, new Guid("af2d6f85-d341-4433-8f21-3f28f816a79e") });

            migrationBuilder.InsertData(
                table: "DeoParceleEntity",
                columns: new[] { "DeoParceleId", "Dodeljena", "ParcelaId", "Povrsina", "RedniBroj" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), false, new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), 100, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DeoParceleEntity_ParcelaId",
                table: "DeoParceleEntity",
                column: "ParcelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_KatastarskaOpstinaId",
                table: "Parcela",
                column: "KatastarskaOpstinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_ZasticenaZonaId",
                table: "Parcela",
                column: "ZasticenaZonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeoParceleEntity");

            migrationBuilder.DropTable(
                name: "Parcela");

            migrationBuilder.DropTable(
                name: "KatastarskaOpstina");

            migrationBuilder.DropTable(
                name: "ZasticenaZona");
        }
    }
}
