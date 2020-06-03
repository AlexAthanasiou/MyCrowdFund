using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCrowdFund.Migrations
{
    public partial class adding_authentication_authorization2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Backer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Backer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Backer");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Backer");
        }
    }
}
