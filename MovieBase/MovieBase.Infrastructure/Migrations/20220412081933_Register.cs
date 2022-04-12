using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBase.Infrastructure.Migrations
{
    public partial class Register : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmographies_Actors_ActorId1",
                table: "Filmographies");

            migrationBuilder.DropIndex(
                name: "IX_Filmographies_ActorId1",
                table: "Filmographies");

            migrationBuilder.DropColumn(
                name: "ActorId1",
                table: "Filmographies");

            migrationBuilder.CreateIndex(
                name: "IX_Filmographies_ActorId",
                table: "Filmographies",
                column: "ActorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmographies_Actors_ActorId",
                table: "Filmographies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmographies_Actors_ActorId",
                table: "Filmographies");

            migrationBuilder.DropIndex(
                name: "IX_Filmographies_ActorId",
                table: "Filmographies");

            migrationBuilder.AddColumn<int>(
                name: "ActorId1",
                table: "Filmographies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Filmographies_ActorId1",
                table: "Filmographies",
                column: "ActorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmographies_Actors_ActorId1",
                table: "Filmographies",
                column: "ActorId1",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
