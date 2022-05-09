using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBase.Infrastructure.Migrations
{
    public partial class Actorchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Actors");
        }
    }
}
