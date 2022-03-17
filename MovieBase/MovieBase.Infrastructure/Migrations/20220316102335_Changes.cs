using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBase.Infrastructure.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_MovieStars_MovieStarId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_CriticReviews_Movies_MovieId",
                table: "CriticReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmographies_MovieStars_MovieStarId",
                table: "Filmographies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieStars_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStars_Movies_MovieId1",
                table: "MovieStars");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_MovieStars_MovieStarId",
                table: "PersonalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Movies_MovieId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_MovieStarId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_MovieStars_MovieId1",
                table: "MovieStars");

            migrationBuilder.DropIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Filmographies_MovieStarId",
                table: "Filmographies");

            migrationBuilder.DropIndex(
                name: "IX_Awards_MovieStarId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                table: "MovieStars");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "MovieStarId",
                table: "PersonalDetails",
                newName: "PersonId");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "UserReviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmographyId",
                table: "MovieStars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailsId",
                table: "MovieStars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "CriticReviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieStars_FilmographyId",
                table: "MovieStars",
                column: "FilmographyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStars_PersonalDetailsId",
                table: "MovieStars",
                column: "PersonalDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_ActorId",
                table: "Awards",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_MovieStars_ActorId",
                table: "Awards",
                column: "ActorId",
                principalTable: "MovieStars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CriticReviews_Movies_MovieId",
                table: "CriticReviews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Movies_MovieId",
                table: "UserReviews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_MovieStars_ActorId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_CriticReviews_Movies_MovieId",
                table: "CriticReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStars_Filmographies_FilmographyId",
                table: "MovieStars");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStars_PersonalDetails_PersonalDetailsId",
                table: "MovieStars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Movies_MovieId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_MovieStars_FilmographyId",
                table: "MovieStars");

            migrationBuilder.DropIndex(
                name: "IX_MovieStars_PersonalDetailsId",
                table: "MovieStars");

            migrationBuilder.DropIndex(
                name: "IX_Awards_ActorId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "FilmographyId",
                table: "MovieStars");

            migrationBuilder.DropColumn(
                name: "PersonalDetailsId",
                table: "MovieStars");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Awards");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PersonalDetails",
                newName: "MovieStarId");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "UserReviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MovieId1",
                table: "MovieStars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "CriticReviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_MovieStarId",
                table: "PersonalDetails",
                column: "MovieStarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieStars_MovieId1",
                table: "MovieStars",
                column: "MovieId1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmographies_MovieStarId",
                table: "Filmographies",
                column: "MovieStarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Awards_MovieStarId",
                table: "Awards",
                column: "MovieStarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_MovieStars_MovieStarId",
                table: "Awards",
                column: "MovieStarId",
                principalTable: "MovieStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriticReviews_Movies_MovieId",
                table: "CriticReviews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmographies_MovieStars_MovieStarId",
                table: "Filmographies",
                column: "MovieStarId",
                principalTable: "MovieStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieStars_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "MovieStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStars_Movies_MovieId1",
                table: "MovieStars",
                column: "MovieId1",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_MovieStars_MovieStarId",
                table: "PersonalDetails",
                column: "MovieStarId",
                principalTable: "MovieStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Movies_MovieId",
                table: "UserReviews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
