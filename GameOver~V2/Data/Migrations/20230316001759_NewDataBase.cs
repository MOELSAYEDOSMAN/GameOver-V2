using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOver_V2.Data.Migrations
{
    public partial class NewDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameOverNews",
                columns: table => new
                {
                    IdGameOverNews = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    News = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgSrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dec = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOverNews", x => x.IdGameOverNews);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    IdGame = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lowDec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bigDec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gpu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    downloadNumber = table.Column<int>(type: "int", nullable: false),
                    likeN = table.Column<int>(type: "int", nullable: false),
                    disLikeN = table.Column<int>(type: "int", nullable: false),
                    DateDownload = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<bool>(type: "bit", nullable: false),
                    iconSrc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.IdGame);
                });

            migrationBuilder.CreateTable(
                name: "Groubs",
                columns: table => new
                {
                    IdGroub = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subscriberNumber = table.Column<int>(type: "int", nullable: false),
                    iconImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<bool>(type: "bit", nullable: false),
                    PasswordGroub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groubs", x => x.IdGroub);
                    table.ForeignKey(
                        name: "FK_Groubs_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "userMData",
                columns: table => new
                {
                    IdUserMoreInfromation = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userMData", x => x.IdUserMoreInfromation);
                    table.ForeignKey(
                        name: "FK_userMData_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "buyGames",
                columns: table => new
                {
                    IdbuyGame = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    gameIdGame = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buyGames", x => x.IdbuyGame);
                    table.ForeignKey(
                        name: "FK_buyGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_buyGames_Games_gameIdGame",
                        column: x => x.gameIdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    IdComments = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    gameIdGame = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.IdComments);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Games_gameIdGame",
                        column: x => x.gameIdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageGames",
                columns: table => new
                {
                    IdImageGames = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImgSrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gameIdGame = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGames", x => x.IdImageGames);
                    table.ForeignKey(
                        name: "FK_ImageGames_Games_gameIdGame",
                        column: x => x.gameIdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame");
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    IdChat = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    groubIdGroub = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.IdChat);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_Groubs_groubIdGroub",
                        column: x => x.groubIdGroub,
                        principalTable: "Groubs",
                        principalColumn: "IdGroub",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberGroubs",
                columns: table => new
                {
                    IdSubscriberGroub = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    groubIdGroub = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberGroubs", x => x.IdSubscriberGroub);
                    table.ForeignKey(
                        name: "FK_SubscriberGroubs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubscriberGroubs_Groubs_groubIdGroub",
                        column: x => x.groubIdGroub,
                        principalTable: "Groubs",
                        principalColumn: "IdGroub");
                });

            migrationBuilder.CreateIndex(
                name: "IX_buyGames_gameIdGame",
                table: "buyGames",
                column: "gameIdGame");

            migrationBuilder.CreateIndex(
                name: "IX_buyGames_UserId",
                table: "buyGames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_groubIdGroub",
                table: "Chats",
                column: "groubIdGroub");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserId",
                table: "Chats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_gameIdGame",
                table: "Comments",
                column: "gameIdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Groubs_CreatorId",
                table: "Groubs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageGames_gameIdGame",
                table: "ImageGames",
                column: "gameIdGame");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberGroubs_groubIdGroub",
                table: "SubscriberGroubs",
                column: "groubIdGroub");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberGroubs_UserId",
                table: "SubscriberGroubs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userMData_UserId",
                table: "userMData",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buyGames");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "GameOverNews");

            migrationBuilder.DropTable(
                name: "ImageGames");

            migrationBuilder.DropTable(
                name: "SubscriberGroubs");

            migrationBuilder.DropTable(
                name: "userMData");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Groubs");
        }
    }
}
