using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortolio.Migrations
{
    public partial class useruptade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cv",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NewPassword",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cv",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "users");

            migrationBuilder.DropColumn(
                name: "NewPassword",
                table: "users");
        }
    }
}
