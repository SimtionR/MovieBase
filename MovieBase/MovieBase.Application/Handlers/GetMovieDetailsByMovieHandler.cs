using MediatR;
using MovieBase.Application.Queries;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers
{
    public class GetMovieDetailsByMovieHandler : IRequestHandler<GetMovieDetailsByMovieQuery, MovieDetails>
    {
        private readonly IMovieDetailsRepository _repo;
        public GetMovieDetailsByMovieHandler(IMovieDetailsRepository repo)
        {
            _repo= repo; 
        }
        public async Task<MovieDetails> Handle(GetMovieDetailsByMovieQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetMovieDetailsByMovieAsync(request.MovieId);
        }
    }
}
