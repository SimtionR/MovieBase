using Microsoft.EntityFrameworkCore;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using MovieBase.Core.StrategyRecommandation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Repositoriers
{
    public class MovieRepository : Core.Abstractions.IMovieRepository
    {
        private readonly MovieBaseDbContext _ctx;

        public MovieRepository(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            _ctx.Add(movie);
            await _ctx.SaveChangesAsync();

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            var movies = await _ctx.Movies.ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _ctx.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
            return movie;
        }

        public async Task<Movie> GetMovieByRecommandation(UserPreferences userPreferences, Profile profile)
        {
            userPreferences.CalculateUserPreferances(profile.Ratings);

            var isMovie = userPreferences.CheckWatchListForRecommandation(profile.WatctList);


            RecommandationContext recommandationContext = new RecommandationContext();

            if (isMovie)
            {
                recommandationContext.SetStrategy(new WatchListRecommandation());

                var movie = recommandationContext.RecommandMovie(profile.WatctList, userPreferences);
                return movie;
                

            }
            else
            {
                //var dbMovies = await _ctx.Movies.ToListAsync();
                var goodFilmDetails = new MovieDetails { MetaScore = 10, UserRating = 10 };
                var dbMovies = new List<Movie>() { new Movie { Name = "goodFilm", TypeOf = "Drama", MovieDetails = goodFilmDetails } };

                recommandationContext.SetStrategy(new MovieBaseRecommandation());
                var movie = recommandationContext.RecommandMovie(dbMovies, userPreferences);
                return movie;
                
                

            }
        }
    }
}
