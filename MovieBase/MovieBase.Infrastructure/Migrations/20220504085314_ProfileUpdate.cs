using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBase.Infrastructure.Migrations
{
    public partial class ProfileUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Profiles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Profiles");
        }
    }
}
