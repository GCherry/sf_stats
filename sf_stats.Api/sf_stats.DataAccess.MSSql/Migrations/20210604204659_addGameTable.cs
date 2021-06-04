using Microsoft.EntityFrameworkCore.Migrations;

namespace sf_stats.DataAccess.MSSql.Migrations
{
    public partial class addGameTable : Migration
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
                    Away_TeamId = table.Column<int>(type: "int", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game",
                schema: "dbo");
        }
    }
}
