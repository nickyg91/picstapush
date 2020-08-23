using Microsoft.EntityFrameworkCore.Migrations;

namespace Picstapush.Web.Migrations
{
    public partial class AddForcePasswordChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "force_password_change",
                table: "user",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "force_password_change",
                table: "user");
        }
    }
}
