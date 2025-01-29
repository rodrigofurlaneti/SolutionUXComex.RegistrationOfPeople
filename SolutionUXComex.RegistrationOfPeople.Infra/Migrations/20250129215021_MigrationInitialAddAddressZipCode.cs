using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionUXComex.RegistrationOfPeople.Infra.Migrations
{
    public partial class MigrationInitialAddAddressZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Person");
        }
    }
}
