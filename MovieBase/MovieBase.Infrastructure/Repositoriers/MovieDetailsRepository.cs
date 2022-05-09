using Microsoft.EntityFrameworkCore;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Repositoriers
{
    public class MovieDetailsRepository : IMovieDetailsRepository
    {
        private readonly MovieBaseDbContext _ctx;
        public MovieDetailsRepository(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<MovieDetails> CreateMovieDetailsAsync(MovieDetails movieDetails, List<int> actors, List<int> genres)
        {
            foreach(var actor in actors)
            {
                var actorToAdd = _ctx.Actors.Where(a => a.Id == actor).FirstOrDefault();
                movieDetails.Actors.Add(actorToAdd);
                
            }
            foreach(var genre in genres)
            {
                var genreToAdd =_ctx.Genres.Where( g => g.Id == genre).FirstOrDefault();
                movieDetails.Genres.Add(genreToAdd);
            }

            _ctx.MovieDetails.Add(movieDetails);
            await _ctx.SaveChangesAsync();

            var movie = _ctx.Movies.Where(m => m.Id == movieDetails.MovieId).FirstOrDefault();
            _ctx.Update(movie.MovieDetails = movieDetails);
           // _ctx.Update(movie.MovieDetailsId = movieDetails.Id);

            await _ctx.SaveChangesAsync();

            return movieDetails;


            
        }

        public async Task<MovieDetails> GetMovieDetailsByMovieAsync(int movieId)
        {
            return await _ctx.MovieDetails.Include(m=> m.Actors).Include(m=> m.Genres).Where(m => m.MovieId == movieId).FirstOrDefaultAsync();
        }
    }
}
