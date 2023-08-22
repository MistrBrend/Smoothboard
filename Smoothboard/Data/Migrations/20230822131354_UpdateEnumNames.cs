using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smoothboard.Data.Migrations
{
    public partial class UpdateEnumNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hoogte",
                table: "Opdracht",
                newName: "Breedte");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Breedte",
                table: "Opdracht",
                newName: "Hoogte");
        }
    }
}
