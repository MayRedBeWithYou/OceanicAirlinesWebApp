using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanicAirlinesWebApp.Migrations
{
    public partial class MoreClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Parcel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Parcel");
        }
    }
}
