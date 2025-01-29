using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionUXComex.RegistrationOfPeople.Infra.Migrations
{
    public partial class MigrationInitialAddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Person");
        }
    }
}
