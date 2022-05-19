using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanicAirlinesWebApp.Migrations
{
    public partial class Updateparcels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Parcel",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "Parcel",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "Parcel",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Parcel");
        }
    }
}
