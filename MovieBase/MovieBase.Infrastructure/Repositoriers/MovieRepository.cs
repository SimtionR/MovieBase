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
    }
}
