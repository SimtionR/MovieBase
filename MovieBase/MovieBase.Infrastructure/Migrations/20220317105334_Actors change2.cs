using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBase.Infrastructure.Migrations
{
    public partial class Actorschange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_MovieStars_ActorId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmographies_MovieStars_ActorId1",
                table: "Filmographies");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStars_MovieDetails_MovieDetailsId",
                table: "MovieStars");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_MovieStars_ActorId",
                table: "PersonalDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieStars",
                table: "MovieStars");

            migrationBuilder.RenameTable(
                name: "MovieStars",
                newName: "Actors");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStars_MovieDetailsId",
                table: "Actors",
                newName: "IX_Actors_MovieDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_MovieDetails_MovieDetailsId",
                table: "Actors",
                column: "MovieDetailsId",
                principalTable: "MovieDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Actors_ActorId",
                table: "Awards",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmographies_Actors_ActorId1",
                table: "Filmographies",
                column: "ActorId1",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_Actors_ActorId",
                table: "PersonalDetails",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_MovieDetails_MovieDetailsId",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Actors_ActorId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmographies_Actors_ActorId1",
                table: "Filmographies");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_Actors_ActorId",
                table: "PersonalDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "MovieStars");

            migrationBuilder.RenameIndex(
                name: "IX_Actors_MovieDetailsId",
                table: "MovieStars",
                newName: "IX_MovieStars_MovieDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieStars",
                table: "MovieStars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_MovieStars_ActorId",
                table: "Awards",
                column: "ActorId",
                principalTable: "MovieStars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmographies_MovieStars_ActorId1",
                table: "Filmographies",
                column: "ActorId1",
                principalTable: "MovieStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStars_MovieDetails_MovieDetailsId",
                table: "MovieStars",
                column: "MovieDetailsId",
                principalTable: "MovieDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_MovieStars_ActorId",
                table: "PersonalDetails",
                column: "ActorId",
                principalTable: "MovieStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
