using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.RequestModels;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.Application.Commands.Reviews;
using MovieBase.Application.Queries.ReviewQueries;
using MovieBase.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    public class ReviewController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProfileRepository _repo;
        public ReviewController(IMediator mediator, IMapper mapper, IProfileRepository repo)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repo = repo;
        }
        
        [HttpPost]
        [Route("createUserReview")]
        public async Task<ActionResult<UserReviewResponseModel>> CreateUserReview(UserReviewRequestModel userReviewModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var profile = await _repo.GetProfileByUserId(userId);
            var profileId = profile.Id;

            userReviewModel.ProfileId = profileId;

            var userReviewCommand = _mapper.Map<AddReviewCommand>(userReviewModel);

            var result = await _mediator.Send(userReviewCommand);

            if(result ==null)
            {
                return BadRequest();
            }

            var movieResponse = _mapper.Map<UserReviewResponseModel>(result);

            return movieResponse;
        }

        [HttpGet]
        [Route("getUserReview/{reviewId}")]
        public async Task<ActionResult<UserReviewResponseModel>> GetUserReviewById(int reviewId)
        {
            var command = new GetReviewByIdQuery { ReviewId = reviewId };
            var result = await _mediator.Send(command);

            if(result==null)
            {
                return NotFound();
            }

            return _mapper.Map<UserReviewResponseModel>(result);
        }
        [HttpGet]
        [Route("reviews/{movieId}")]
        public async Task<IEnumerable<UserReviewResponseModel>> GetReviewsByMovieId(int movieId)
        {
            var command = new GetReviewsByMovieIdQuery { MovieId = movieId };
            var result = await _mediator.Send(command);

            var userReviewList = new List<UserReviewResponseModel>();
            foreach(var review in result)
            {
                var userReviewResponse = _mapper.Map<UserReviewResponseModel>(review);
                userReviewList.Add(userReviewResponse);
            }

            return userReviewList;
        }
    }
}
