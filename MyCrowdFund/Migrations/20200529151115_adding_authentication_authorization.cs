using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCrowdFund.Migrations
{
    public partial class adding_authentication_authorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "ProjectCreator",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "ProjectCreator",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "ProjectCreator");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "ProjectCreator");
        }
    }
}
