using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOver_V2.Data.Migrations
{
    public partial class AddClassFrindAndChatAndPostsAndShare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat_User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SendId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReciveId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Sent = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_User_AspNetUsers_ReciveId",
                        column: x => x.ReciveId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chat_User_AspNetUsers_SendId",
                        column: x => x.SendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Frinds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SendId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReciveId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    acctept = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frinds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frinds_AspNetUsers_ReciveId",
                        column: x => x.ReciveId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Frinds_AspNetUsers_SendId",
                        column: x => x.SendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostsUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DecPost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhUpload = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nLike = table.Column<int>(type: "int", nullable: false),
                    nDisLike = table.Column<int>(type: "int", nullable: false),
                    Comments_ = table.Column<int>(type: "int", nullable: false),
                    Share_ = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostsUsers_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SharePosts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostUId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsShareId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    nLike = table.Column<int>(type: "int", nullable: false),
                    nDisLike = table.Column<int>(type: "int", nullable: false),
                    Comments_ = table.Column<int>(type: "int", nullable: false),
                    Share_ = table.Column<int>(type: "int", nullable: false),
                    W_share = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharePosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharePosts_AspNetUsers_UsShareId",
                        column: x => x.UsShareId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SharePosts_PostsUsers_PostUId",
                        column: x => x.PostUId,
                        principalTable: "PostsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentsPosts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whe_Write = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WriteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SharePId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    nlike = table.Column<int>(type: "int", nullable: false),
                    nDislike = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentsPosts_AspNetUsers_WriteId",
                        column: x => x.WriteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentsPosts_PostsUsers_PostId",
                        column: x => x.PostId,
                        principalTable: "PostsUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentsPosts_SharePosts_SharePId",
                        column: x => x.SharePId,
                        principalTable: "SharePosts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_User_ReciveId",
                table: "Chat_User",
                column: "ReciveId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_User_SendId",
                table: "Chat_User",
                column: "SendId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsPosts_PostId",
                table: "CommentsPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsPosts_SharePId",
                table: "CommentsPosts",
                column: "SharePId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsPosts_WriteId",
                table: "CommentsPosts",
                column: "WriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Frinds_ReciveId",
                table: "Frinds",
                column: "ReciveId");

            migrationBuilder.CreateIndex(
                name: "IX_Frinds_SendId",
                table: "Frinds",
                column: "SendId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsUsers_userId",
                table: "PostsUsers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SharePosts_PostUId",
                table: "SharePosts",
                column: "PostUId");

            migrationBuilder.CreateIndex(
                name: "IX_SharePosts_UsShareId",
                table: "SharePosts",
                column: "UsShareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat_User");

            migrationBuilder.DropTable(
                name: "CommentsPosts");

            migrationBuilder.DropTable(
                name: "Frinds");

            migrationBuilder.DropTable(
                name: "SharePosts");

            migrationBuilder.DropTable(
                name: "PostsUsers");
        }
    }
}
