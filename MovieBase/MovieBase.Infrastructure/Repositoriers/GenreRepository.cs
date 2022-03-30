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
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieBaseDbContext _ctx;

        public GenreRepository(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            _ctx.Genres.Add(genre);
            await _ctx.SaveChangesAsync();
            return genre;
        }

        public async Task<IEnumerable<Genre>> GetAllGenreAsync()
        {
            var genres = await _ctx.Genres.ToListAsync();
            return genres;
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
          var genre = await _ctx.Genres.Where(g => g.Id == id).FirstOrDefaultAsync();

          return genre;
        }

        public async Task<Genre> GetGenreByNameAsync(string name)
        {
            var genre = await _ctx.Genres.Where(g => g.Name == name).FirstOrDefaultAsync();

            return genre;
        }
    }
}
