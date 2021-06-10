using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sf_stats.DataAccess.MSSql.Migrations
{
    public partial class linkingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamSeason",
                schema: "dbo",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeason", x => new { x.TeamId, x.SeasonId });
                    table.ForeignKey(
                        name: "FK_TeamSeason_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "dbo",
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSeason_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    Home_TeamSeasonId = table.Column<int>(type: "int", nullable: false),
                    Away_TeamSeasonId = table.Column<int>(type: "int", nullable: false),
                    GameDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Home_Score = table.Column<int>(type: "int", nullable: true),
                    Away_Score = table.Column<int>(type: "int", nullable: true),
                    Home_TeamSeasonTeamId = table.Column<int>(type: "int", nullable: false),
                    Home_TeamSeasonSeasonId = table.Column<int>(type: "int", nullable: false),
                    Away_TeamSeasonTeamId = table.Column<int>(type: "int", nullable: false),
                    Away_TeamSeasonSeasonId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Game_TeamSeason_Away_TeamSeasonTeamId_Away_TeamSeasonSeasonId",
                        columns: x => new { x.Away_TeamSeasonTeamId, x.Away_TeamSeasonSeasonId },
                        principalSchema: "dbo",
                        principalTable: "TeamSeason",
                        principalColumns: new[] { "TeamId", "SeasonId" });
                    table.ForeignKey(
                        name: "FK_Game_TeamSeason_Home_TeamSeasonTeamId_Home_TeamSeasonSeasonId",
                        columns: x => new { x.Home_TeamSeasonTeamId, x.Home_TeamSeasonSeasonId },
                        principalSchema: "dbo",
                        principalTable: "TeamSeason",
                        principalColumns: new[] { "TeamId", "SeasonId" });
                });

            migrationBuilder.CreateTable(
                name: "TeamSeasonPlayer",
                schema: "dbo",
                columns: table => new
                {
                    TeamSeasonId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TeamSeasonTeamId = table.Column<int>(type: "int", nullable: false),
                    TeamSeasonSeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeasonPlayer", x => new { x.TeamSeasonId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_TeamSeasonPlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSeasonPlayer_TeamSeason_TeamSeasonTeamId_TeamSeasonSeasonId",
                        columns: x => new { x.TeamSeasonTeamId, x.TeamSeasonSeasonId },
                        principalSchema: "dbo",
                        principalTable: "TeamSeason",
                        principalColumns: new[] { "TeamId", "SeasonId" },
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Game_Away_TeamSeasonTeamId_Away_TeamSeasonSeasonId",
                schema: "dbo",
                table: "Game",
                columns: new[] { "Away_TeamSeasonTeamId", "Away_TeamSeasonSeasonId" });

            migrationBuilder.CreateIndex(
                name: "IX_Game_DivisionId",
                schema: "dbo",
                table: "Game",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_Home_TeamSeasonTeamId_Home_TeamSeasonSeasonId",
                schema: "dbo",
                table: "Game",
                columns: new[] { "Home_TeamSeasonTeamId", "Home_TeamSeasonSeasonId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeason_SeasonId",
                schema: "dbo",
                table: "TeamSeason",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasonPlayer_PlayerId",
                schema: "dbo",
                table: "TeamSeasonPlayer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasonPlayer_TeamSeasonTeamId_TeamSeasonSeasonId",
                schema: "dbo",
                table: "TeamSeasonPlayer",
                columns: new[] { "TeamSeasonTeamId", "TeamSeasonSeasonId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TeamSeasonPlayer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Game",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TeamSeason",
                schema: "dbo");
        }
    }
}
