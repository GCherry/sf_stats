using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sf_stats.DataAccess.MSSql.Migrations
{
    public partial class addLinkingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "Team",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                schema: "dbo",
                table: "Season",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Game",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Home_Score = table.Column<int>(type: "int", nullable: true),
                    Away_Score = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamSeason",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeason", x => x.Id);
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
                name: "TeamSeasonGame",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    TeamSeasonId = table.Column<int>(type: "int", nullable: false),
                    IsHomeTeam = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeasonGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSeasonGame_Game_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSeasonGame_TeamSeason_TeamSeasonId",
                        column: x => x.TeamSeasonId,
                        principalSchema: "dbo",
                        principalTable: "TeamSeason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSeasonPlayer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamSeasonId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeasonPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSeasonPlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSeasonPlayer_TeamSeason_TeamSeasonId",
                        column: x => x.TeamSeasonId,
                        principalSchema: "dbo",
                        principalTable: "TeamSeason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStat",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamSeasonPlayerId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    StatTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
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
                        name: "FK_PlayerStat_StatType_StatTypeId",
                        column: x => x.StatTypeId,
                        principalSchema: "dbo",
                        principalTable: "StatType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStat_TeamSeasonPlayer_TeamSeasonPlayerId",
                        column: x => x.TeamSeasonPlayerId,
                        principalSchema: "dbo",
                        principalTable: "TeamSeasonPlayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Season_DivisionId",
                schema: "dbo",
                table: "Season",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_GameId",
                schema: "dbo",
                table: "PlayerStat",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_StatTypeId",
                schema: "dbo",
                table: "PlayerStat",
                column: "StatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_TeamSeasonPlayerId",
                schema: "dbo",
                table: "PlayerStat",
                column: "TeamSeasonPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeason_SeasonId",
                schema: "dbo",
                table: "TeamSeason",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeason_TeamId",
                schema: "dbo",
                table: "TeamSeason",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasonGame_GameId",
                schema: "dbo",
                table: "TeamSeasonGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasonGame_TeamSeasonId",
                schema: "dbo",
                table: "TeamSeasonGame",
                column: "TeamSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasonPlayer_PlayerId",
                schema: "dbo",
                table: "TeamSeasonPlayer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasonPlayer_TeamSeasonId",
                schema: "dbo",
                table: "TeamSeasonPlayer",
                column: "TeamSeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Division_DivisionId",
                schema: "dbo",
                table: "Season",
                column: "DivisionId",
                principalSchema: "dbo",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Season_Division_DivisionId",
                schema: "dbo",
                table: "Season");

            migrationBuilder.DropTable(
                name: "PlayerStat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TeamSeasonGame",
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

            migrationBuilder.DropIndex(
                name: "IX_Season_DivisionId",
                schema: "dbo",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "dbo",
                table: "Season");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "Team",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
