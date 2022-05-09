using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBase.Infrastructure.Migrations
{
    public partial class FkUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieDetailsId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieDetailsId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
