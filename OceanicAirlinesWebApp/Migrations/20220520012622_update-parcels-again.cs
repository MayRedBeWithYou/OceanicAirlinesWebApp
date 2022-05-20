using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanicAirlinesWebApp.Migrations
{
    public partial class updateparcelsagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Parcel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Parcel",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Time",
                table: "Parcel",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Parcel");
        }
    }
}
