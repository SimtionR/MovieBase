using MediatR;
using MovieBase.Application.Queries.ReviewQueries;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.ReviewHandlers
{
    public class GetReviewsByMovieIdQueryHandler : IRequestHandler<GetReviewsByMovieIdQuery, IEnumerable<UserReview>>
    {
        private readonly IUserReviewRepository _repo;
        public GetReviewsByMovieIdQueryHandler(IUserReviewRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<UserReview>> Handle(GetReviewsByMovieIdQuery request, CancellationToken cancellationToken)
        {
            var userReviews = await _repo.GetAllReviewsByMovieIdAsync(request.MovieId);
            return userReviews;
        }
    }
}
