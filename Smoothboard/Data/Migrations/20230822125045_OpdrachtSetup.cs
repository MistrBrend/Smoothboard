using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smoothboard.Data.Migrations
{
    public partial class OpdrachtSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opdracht",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(type: "int", nullable: false),
                    DatumGebracht = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumOpgehaald = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AkkoordDesign = table.Column<bool>(type: "bit", nullable: false),
                    SurfboardDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lengte = table.Column<int>(type: "int", nullable: false),
                    Breedte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opdracht", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opdracht_Klant_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opdracht_KlantId",
                table: "Opdracht",
                column: "KlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opdracht");
        }
    }
}
