using AutoMapper;
using MediatR;
using MovieBase.Application.Commands.Reviews;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.ReviewHandlers
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, UserReview>
    {
        private readonly IUserReviewRepository _repo;
        private readonly IMapper _mapper;
        public AddReviewCommandHandler(IUserReviewRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<UserReview> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var userReview = _mapper.Map<UserReview>(request);
            userReview.CommentDate = DateTime.Now;
            return await _repo.CreateUserReviewAsync(userReview);
        }
    }
}
