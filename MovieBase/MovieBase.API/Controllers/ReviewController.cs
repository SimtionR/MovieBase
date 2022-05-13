using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.RequestModels;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.Application.Commands.Reviews;
using MovieBase.Application.Queries.ReviewQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    public class ReviewController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ReviewController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("createUserReview")]
        public async Task<ActionResult<UserReviewResponseModel>> CreateUserReview(UserReviewRequestModel userReviewModel)
        {
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
    }
}
