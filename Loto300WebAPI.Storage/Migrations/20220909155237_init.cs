using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loto300WebAPI.Storage.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberBalls = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seesions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumbersDrawn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seesions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketNumber_Seesions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Seesions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketNumber_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "Name", "NumberBalls" },
                values: new object[,]
                {
                    { 1, "Car", 7 },
                    { 2, "Vacation", 6 },
                    { 3, "TV", 5 },
                    { 4, "100$ Gift Card", 4 },
                    { 5, "50$ Gift Card", 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, "Vanja", "Broski", "-nCqDR??	?7FG??", "VanjaBroski", 1 },
                    { 2, "Dinko", "Lord", "M.????:?XU?", "DinkoLord", 1 },
                    { 3, "Monika", "Beluci", "?`KW?(????\\^&??", "MonikaBeluci", 1 },
                    { 4, "Jhony", "Smith", "??MO??%3??O,??<", "Jhony123", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketNumber_SessionId",
                table: "TicketNumber",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketNumber_UserId",
                table: "TicketNumber",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "TicketNumber");

            migrationBuilder.DropTable(
                name: "Seesions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
