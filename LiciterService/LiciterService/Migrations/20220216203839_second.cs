using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiciterService.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zastupnici_Kupci_KupacId",
                table: "Zastupnici");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Zastupnici");

            migrationBuilder.AlterColumn<Guid>(
                name: "KupacId",
                table: "Zastupnici",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Zastupnici_Kupci_KupacId",
                table: "Zastupnici",
                column: "KupacId",
                principalTable: "Kupci",
                principalColumn: "KupacId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zastupnici_Kupci_KupacId",
                table: "Zastupnici");

            migrationBuilder.AlterColumn<Guid>(
                name: "KupacId",
                table: "Zastupnici",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Zastupnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zastupnici_Kupci_KupacId",
                table: "Zastupnici",
                column: "KupacId",
                principalTable: "Kupci",
                principalColumn: "KupacId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
