using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBase.Infrastructure.Migrations
{
    public partial class ConnectionChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Profiles_ProfileId",
                table: "Connections");

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "ResponsePendings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "ResponsePendings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderPhoto",
                table: "ResponsePendings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Connections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PoriflePicture",
                table: "Connections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUserName",
                table: "Connections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Profiles_ProfileId",
                table: "Connections",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Profiles_ProfileId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "ResponsePendings");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "ResponsePendings");

            migrationBuilder.DropColumn(
                name: "SenderPhoto",
                table: "ResponsePendings");

            migrationBuilder.DropColumn(
                name: "PoriflePicture",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "ProfileUserName",
                table: "Connections");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Connections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Profiles_ProfileId",
                table: "Connections",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
