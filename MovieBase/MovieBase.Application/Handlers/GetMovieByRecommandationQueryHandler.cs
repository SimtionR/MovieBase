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
    public class GetMovieByRecommandationQueryHandler : IRequestHandler<GetMovieByRecommandationQuery, Movie>
    {
        private readonly IMovieRepository _repo;

        public GetMovieByRecommandationQueryHandler(IMovieRepository repo)
        {
            _repo = repo;
        }
        public Task<Movie> Handle(GetMovieByRecommandationQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetMovieByRecommandation(request.userPreferences, request.profile);
        }
    }
}
