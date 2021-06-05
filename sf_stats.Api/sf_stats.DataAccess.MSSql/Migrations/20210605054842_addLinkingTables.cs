using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sf_stats.DataAccess.MSSql.Migrations
{
    public partial class addLinkingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    Home_TeamId = table.Column<int>(type: "int", nullable: false),
                    Away_TeamId = table.Column<int>(type: "int", nullable: false),
                    GameDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Home_Score = table.Column<int>(type: "int", nullable: true),
                    Away_Score = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "dbo",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "dbo",
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_Team_Away_TeamId",
                        column: x => x.Away_TeamId,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Game_Team_Home_TeamId",
                        column: x => x.Home_TeamId,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerStat",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    StatTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStat_Game_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStat_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStat_StatType_StatTypeId",
                        column: x => x.StatTypeId,
                        principalSchema: "dbo",
                        principalTable: "StatType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_Away_TeamId",
                schema: "dbo",
                table: "Game",
                column: "Away_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_DivisionId",
                schema: "dbo",
                table: "Game",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_Home_TeamId",
                schema: "dbo",
                table: "Game",
                column: "Home_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_SeasonId",
                schema: "dbo",
                table: "Game",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_GameId",
                schema: "dbo",
                table: "PlayerStat",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_PlayerId",
                schema: "dbo",
                table: "PlayerStat",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_StatTypeId",
                schema: "dbo",
                table: "PlayerStat",
                column: "StatTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Game",
                schema: "dbo");
        }
    }
}
