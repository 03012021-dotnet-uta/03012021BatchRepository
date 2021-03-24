using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpsGame_NoDb.Migrations
{
    public partial class rpsmigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player1PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Player2PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    p1RoundWins = table.Column<int>(type: "int", nullable: false),
                    p2RoundWins = table.Column<int>(type: "int", nullable: false),
                    ties = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matchs_Players_Player1PlayerId",
                        column: x => x.Player1PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_Players_Player2PlayerId",
                        column: x => x.Player2PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player1Choice = table.Column<int>(type: "int", nullable: false),
                    Player2Choice = table.Column<int>(type: "int", nullable: false),
                    WinningPlayerPlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Rounds_Players_WinningPlayerPlayerId",
                        column: x => x.WinningPlayerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_Player1PlayerId",
                table: "Matchs",
                column: "Player1PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_Player2PlayerId",
                table: "Matchs",
                column: "Player2PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_WinningPlayerPlayerId",
                table: "Rounds",
                column: "WinningPlayerPlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
