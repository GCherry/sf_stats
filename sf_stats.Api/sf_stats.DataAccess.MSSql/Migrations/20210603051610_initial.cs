using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sf_stats.DataAccess.MSSql.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Log",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    TimeStamp = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "xml", nullable: true),
                    LogEvent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log",
                schema: "dbo");
        }
    }
}
