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
    public class GetReiewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, UserReview>
    {
        private readonly IUserReviewRepository _repo;

        public GetReiewByIdQueryHandler(IUserReviewRepository repo)
        {
            _repo = repo;
        }
        public async Task<UserReview> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetReviewByIdAsync(request.ReviewId);
        }
    }
}
