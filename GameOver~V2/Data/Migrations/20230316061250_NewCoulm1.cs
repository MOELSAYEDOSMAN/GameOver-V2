using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOver_V2.Data.Migrations
{
    public partial class NewCoulm1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "numberDisLike",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numberLike",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numberDisLike",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "numberLike",
                table: "Comments");
        }
    }
}
