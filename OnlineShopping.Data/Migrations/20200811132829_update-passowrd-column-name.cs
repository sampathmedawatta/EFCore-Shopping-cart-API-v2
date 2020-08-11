using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Data.Migrations
{
    public partial class updatepassowrdcolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "CustomerPassword");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "CustomerPassword",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "CustomerPassword");

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "CustomerPassword",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
