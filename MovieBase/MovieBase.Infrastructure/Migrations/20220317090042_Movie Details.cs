using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBase.Infrastructure.Migrations
{
    public partial class MovieDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Movies_MovieId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStars_Movies_MovieId",
                table: "MovieStars");

            migrationBuilder.DropColumn(
                name: "MetaScore",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieStars",
                newName: "MovieDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStars_MovieId",
                table: "MovieStars",
                newName: "IX_MovieStars_MovieDetailsId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Genre",
                newName: "MovieDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Genre_MovieId",
                table: "Genre",
                newName: "IX_Genre_MovieDetailsId");

            migrationBuilder.AddColumn<int>(
                name: "MovieDetailsId",
                table: "UserReviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieDetailsId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieDetailsId",
                table: "CriticReviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovieDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MetaScore = table.Column<double>(type: "float", nullable: false),
                    UserRating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieDetails_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_MovieDetailsId",
                table: "UserReviews",
                column: "MovieDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CriticReviews_MovieDetailsId",
                table: "CriticReviews",
                column: "MovieDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_MovieId",
                table: "MovieDetails",
                column: "MovieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CriticReviews_MovieDetails_MovieDetailsId",
                table: "CriticReviews",
                column: "MovieDetailsId",
                principalTable: "MovieDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_MovieDetails_MovieDetailsId",
                table: "Genre",
                column: "MovieDetailsId",
                principalTable: "MovieDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStars_MovieDetails_MovieDetailsId",
                table: "MovieStars",
                column: "MovieDetailsId",
                principalTable: "MovieDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_MovieDetails_MovieDetailsId",
                table: "UserReviews",
                column: "MovieDetailsId",
                principalTable: "MovieDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriticReviews_MovieDetails_MovieDetailsId",
                table: "CriticReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_MovieDetails_MovieDetailsId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStars_MovieDetails_MovieDetailsId",
                table: "MovieStars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_MovieDetails_MovieDetailsId",
                table: "UserReviews");

            migrationBuilder.DropTable(
                name: "MovieDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserReviews_MovieDetailsId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_CriticReviews_MovieDetailsId",
                table: "CriticReviews");

            migrationBuilder.DropColumn(
                name: "MovieDetailsId",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "MovieDetailsId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieDetailsId",
                table: "CriticReviews");

            migrationBuilder.RenameColumn(
                name: "MovieDetailsId",
                table: "MovieStars",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStars_MovieDetailsId",
                table: "MovieStars",
                newName: "IX_MovieStars_MovieId");

            migrationBuilder.RenameColumn(
                name: "MovieDetailsId",
                table: "Genre",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Genre_MovieDetailsId",
                table: "Genre",
                newName: "IX_Genre_MovieId");

            migrationBuilder.AddColumn<double>(
                name: "MetaScore",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "UserRating",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Movies_MovieId",
                table: "Genre",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStars_Movies_MovieId",
                table: "MovieStars",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
