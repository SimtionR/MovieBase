using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Abstractions
{
    public interface IMovieRepository
    {
        Task<Movie> CreateMovieAsync(Movie movie);
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> GetMovieByRecommandation(UserPreferences userPreferences, Profile profile);
        Task<bool> DeleteMovie(int movieId);
    }
}
