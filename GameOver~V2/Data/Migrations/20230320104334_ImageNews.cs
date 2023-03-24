using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOver_V2.Data.Migrations
{
    public partial class ImageNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BackGroundImageNews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsIdGameOverNews = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackGroundImageNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackGroundImageNews_GameOverNews_NewsIdGameOverNews",
                        column: x => x.NewsIdGameOverNews,
                        principalTable: "GameOverNews",
                        principalColumn: "IdGameOverNews",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackGroundImageNews_NewsIdGameOverNews",
                table: "BackGroundImageNews",
                column: "NewsIdGameOverNews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackGroundImageNews");
        }
    }
}
