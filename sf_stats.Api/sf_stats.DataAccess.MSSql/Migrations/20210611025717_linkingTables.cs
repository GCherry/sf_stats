using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sf_stats.DataAccess.MSSql.Migrations
{
    public partial class linkingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                schema: "dbo",
                table: "TeamSeasonPlayer",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "TeamSeasonPlayer",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                schema: "dbo",
                table: "TeamSeason",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "TeamSeason",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PlayerStat",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "PlayerStat",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Game",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Game",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "TeamSeasonPlayer");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "TeamSeasonPlayer");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "TeamSeason");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "TeamSeason");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "PlayerStat");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "PlayerStat");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Game");
        }
    }
}
