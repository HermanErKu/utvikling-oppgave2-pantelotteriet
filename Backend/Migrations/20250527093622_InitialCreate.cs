using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pantemaskiner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxPant = table.Column<int>(type: "integer", nullable: false),
                    CurrentPant = table.Column<int>(type: "integer", nullable: false),
                    Area = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pantemaskiner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PantedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PantemaskinId = table.Column<int>(type: "integer", nullable: false),
                    PantAmount = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PantedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PantedItems_Pantemaskiner_PantemaskinId",
                        column: x => x.PantemaskinId,
                        principalTable: "Pantemaskiner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PantedItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pantelotterier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrawDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WinnerUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pantelotterier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pantelotterier_Users_WinnerUserId",
                        column: x => x.WinnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LotteryTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PantId = table.Column<int>(type: "integer", nullable: false),
                    LotteriId = table.Column<int>(type: "integer", nullable: false),
                    PantemaskinId = table.Column<int>(type: "integer", nullable: false),
                    Barcode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotteryTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotteryTickets_PantedItems_PantId",
                        column: x => x.PantId,
                        principalTable: "PantedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotteryTickets_Pantelotterier_LotteriId",
                        column: x => x.LotteriId,
                        principalTable: "Pantelotterier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotteryTickets_Pantemaskiner_PantemaskinId",
                        column: x => x.PantemaskinId,
                        principalTable: "Pantemaskiner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotteryTickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LotteryTickets_LotteriId",
                table: "LotteryTickets",
                column: "LotteriId");

            migrationBuilder.CreateIndex(
                name: "IX_LotteryTickets_PantemaskinId",
                table: "LotteryTickets",
                column: "PantemaskinId");

            migrationBuilder.CreateIndex(
                name: "IX_LotteryTickets_PantId",
                table: "LotteryTickets",
                column: "PantId");

            migrationBuilder.CreateIndex(
                name: "IX_LotteryTickets_UserId",
                table: "LotteryTickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PantedItems_PantemaskinId",
                table: "PantedItems",
                column: "PantemaskinId");

            migrationBuilder.CreateIndex(
                name: "IX_PantedItems_UserId",
                table: "PantedItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pantelotterier_WinnerUserId",
                table: "Pantelotterier",
                column: "WinnerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LotteryTickets");

            migrationBuilder.DropTable(
                name: "PantedItems");

            migrationBuilder.DropTable(
                name: "Pantelotterier");

            migrationBuilder.DropTable(
                name: "Pantemaskiner");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
