using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Picstapush.Web.Migrations
{
    public partial class UpdatePasswordColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "user",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "password",
                table: "user",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
