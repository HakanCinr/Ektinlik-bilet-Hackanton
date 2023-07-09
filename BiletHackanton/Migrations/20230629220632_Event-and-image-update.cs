using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiletHackanton.Migrations
{
    public partial class Eventandimageupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterURL",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Events",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterURL",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Events");
        }
    }
}
