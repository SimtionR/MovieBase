using MediatR;
using MovieBase.Application.Queries.MovieQueries;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.MovieHandleres
{
    public class GetMoviesBySearchQueryHandler : IRequestHandler<GetMoviesBySearchQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _repo;

        public GetMoviesBySearchQueryHandler(IMovieRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Movie>> Handle(GetMoviesBySearchQuery request, CancellationToken cancellationToken)
        {
            var movies = await _repo.GetMoviesBySearchAsync(request.Search);
            return movies;
        }
    }
}
