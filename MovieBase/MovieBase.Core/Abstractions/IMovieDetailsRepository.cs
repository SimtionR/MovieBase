using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Abstractions
{
    public interface IMovieDetailsRepository
    {
        Task<MovieDetails> CreateMovieDetailsAsync(MovieDetails movieDetails, List<int> actors, List<int> genres);
        Task<MovieDetails> GetMovieDetailsByMovieAsync(int movieId);
    }
}
