using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemeString",
                table: "Memes");

            migrationBuilder.AddColumn<byte[]>(
                name: "MemeByteArray",
                table: "Memes",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemeByteArray",
                table: "Memes");

            migrationBuilder.AddColumn<string>(
                name: "MemeString",
                table: "Memes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
