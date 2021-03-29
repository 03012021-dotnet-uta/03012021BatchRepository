using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memes_Persons_PersonId1",
                table: "Memes");

            migrationBuilder.DropIndex(
                name: "IX_Memes_PersonId1",
                table: "Memes");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "Memes");

            migrationBuilder.AddColumn<DateTime>(
                name: "MemberSince",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Persons",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Persons",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberSince",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Persons");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId1",
                table: "Memes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memes_PersonId1",
                table: "Memes",
                column: "PersonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Memes_Persons_PersonId1",
                table: "Memes",
                column: "PersonId1",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
