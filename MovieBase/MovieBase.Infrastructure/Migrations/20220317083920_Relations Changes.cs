using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBase.Infrastructure.Migrations
{
    public partial class RelationsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieStars_Filmographies_FilmographyId",
                table: "MovieStars");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStars_PersonalDetails_PersonalDetailsId",
                table: "MovieStars");

            migrationBuilder.DropIndex(
                name: "IX_MovieStars_FilmographyId",
                table: "MovieStars");

            migrationBuilder.DropIndex(
                name: "IX_MovieStars_PersonalDetailsId",
                table: "MovieStars");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PersonalDetails",
                newName: "ActorId");

            migrationBuilder.RenameColumn(
                name: "MovieStarId",
                table: "Filmographies",
                newName: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_ActorId",
                table: "PersonalDetails",
                column: "ActorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filmographies_ActorId",
                table: "Filmographies",
                column: "ActorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmographies_MovieStars_ActorId",
                table: "Filmographies",
                column: "ActorId",
                principalTable: "MovieStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_MovieStars_ActorId",
                table: "PersonalDetails",
                column: "ActorId",
                principalTable: "MovieStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmographies_MovieStars_ActorId",
                table: "Filmographies");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_MovieStars_ActorId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_ActorId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_Filmographies_ActorId",
                table: "Filmographies");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "PersonalDetails",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "Filmographies",
                newName: "MovieStarId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStars_FilmographyId",
                table: "MovieStars",
                column: "FilmographyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStars_PersonalDetailsId",
                table: "MovieStars",
                column: "PersonalDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStars_Filmographies_FilmographyId",
                table: "MovieStars",
                column: "FilmographyId",
                principalTable: "Filmographies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStars_PersonalDetails_PersonalDetailsId",
                table: "MovieStars",
                column: "PersonalDetailsId",
                principalTable: "PersonalDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
