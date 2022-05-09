using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBase.Infrastructure.Migrations
{
    public partial class ProfileUpdateV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePictureName",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureName",
                table: "Profiles");
        }
    }
}
