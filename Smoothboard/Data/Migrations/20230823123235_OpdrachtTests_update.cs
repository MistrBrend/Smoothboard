using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smoothboard.Data.Migrations
{
    public partial class OpdrachtTests_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KlantNaam",
                table: "OpdrachtTest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KlantNaam",
                table: "OpdrachtTest");
        }
    }
}
