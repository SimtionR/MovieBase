using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.Application.Commands.ProfileCommands;
using MovieBase.Application.Queries;
using MovieBase.Application.Queries.ProfileQueries;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private UserManager<User> _userMananger;
        public ProfileController(IMediator mediator, IMapper mapper, UserManager<User> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userMananger = userManager;
        }

        [HttpGet]
        [Route("userProfile")]
        public async Task<ActionResult<ProfileResponseModel>> GetProfileByUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);


            var result = await _mediator.Send(new GetProfileByUserIdQuery { userId = userId });

            if(result == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProfileResponseModel>(result);

        }

        [HttpGet]
        [Route("profileId/{profileId}")]
        public async Task<ActionResult<ProfileResponseModel>> GetProfileByProfileId(int profileId)
        {
            var result = await _mediator.Send(new GetProfileByProfileIdQuery { profileId = profileId });

            if(result == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProfileResponseModel>(result);
        }

        [HttpPatch]
        [Route("addToWatchList/{movieId}")]
        public async Task<ActionResult> AddToWatchList(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var command = new AddWatchListMovieToProfileCommand { MovieId = movieId, UserId = userId };

            var result = await _mediator.Send(command);

            if(result == true)
            {
                return Ok();
            }
            return BadRequest("Movie already in WatchList");
        }

        [HttpPatch]
        [Route("removeFromWatchList/{movieId}")]
        public async Task<ActionResult> RemoveFromWatchList(int movieid)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var command = new RemoveWatchListMovieFromProfileCommand { MovieId=movieid, UserId = userId };

            var result = await _mediator.Send(command);

            if(result)
            {
                return Ok();
            }
            return BadRequest("Movie is not in WatchList");


        }

        [HttpPatch]
        [Route("removeFromPlayList/{movieId}")]
        public async Task<ActionResult> RemoveFromPlayList(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var command = new RemovePlayListMovieFromProfileCommand { MovieId = movieId, UserId=userId };

            var result = await _mediator.Send(command);

            if(result)
            {
                return Ok();
            }

            return BadRequest("Movie is not in PlayList");
        }
       


        [HttpPatch]
        [Route("addToPlayList/{movieId}")]
        public async Task<ActionResult> AddToPlayList(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var command = new AddPlayListMovieToProfileCommand { MovieId = movieId, UserId = userId };

            var result = await _mediator.Send(command);

            if (result == true)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
