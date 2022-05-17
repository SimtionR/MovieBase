using AutoMapper;
using Azure.Storage.Blobs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.RequestModels;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.Application.Commands.ProfileCommands;
using MovieBase.Application.Queries;
using MovieBase.Application.Queries.ProfileQueries;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using MovieBase.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBlobStorageService _blobStorageService;
        private readonly string _blobCotnaienr = "profilepictures";
        private readonly IProfileRepository _repo;
       

        public ProfileController(IMediator mediator, IMapper mapper, IBlobStorageService blobStorageService, IProfileRepository repo)
        {
            _mediator = mediator;
            _mapper = mapper;
            _blobStorageService = blobStorageService;
            _repo = repo;
           
        }

        [HttpGet]
        [Route("userProfile")]
        public async Task<ActionResult<ProfileResponseModel>> GetProfileByUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);


            var result = await _mediator.Send(new GetProfileByUserIdQuery { userId = userId });

            if (result == null)
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

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProfileResponseModel>(result);
        }

        [HttpPatch]
        [Route("addToWatchList/{movieId}")]
        public async Task<ActionResult<bool>> AddToWatchList(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var command = new AddWatchListMovieToProfileCommand { MovieId = movieId, UserId = userId };

            var result = await _mediator.Send(command);

            return result;
        }

        [HttpPatch]
        [Route("removeFromWatchList/{movieId}")]
        public async Task<ActionResult<bool>> RemoveFromWatchList(int movieid)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var command = new RemoveWatchListMovieFromProfileCommand { MovieId = movieid, UserId = userId };

            var result = await _mediator.Send(command);

            return result;



        }

        [HttpPatch]
        [Route("removeFromPlayList/{movieId}")]
        public async Task<ActionResult<bool>> RemoveFromPlayList(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var command = new RemovePlayListMovieFromProfileCommand { MovieId = movieId, UserId = userId };

            var result = await _mediator.Send(command);

            return result;
        }



        [HttpPatch]
        [Route("addToPlayList/{movieId}")]
        public async Task<ActionResult<bool>> AddToPlayList(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var command = new AddPlayListMovieToProfileCommand { MovieId = movieId, UserId = userId };

            var result = await _mediator.Send(command);

            return result;
        }
        [HttpPatch]
        [Route("updateProfilePicture/{userID}")]
        public async Task<ActionResult> UpdateProfilePicture(string userID)
        {
            var test =await _repo.UpdateProfilePicture(userID);

            return Ok();
        }

        [HttpPost]
        [Route("uploadProfile")]
        public async Task<ActionResult> Upload([FromForm] IFormFile file)
        {
            var idPart = new string(User.FindFirstValue(ClaimTypes.Name).Take(10).ToArray());
            var fileName = new StringBuilder("profilepictures").Append(idPart).ToString();
            
            await _blobStorageService.UploadFileContent(file, _blobCotnaienr, fileName);
            return Ok();
        }

        /*[HttpGet]
        [Route("getProfilePicture")]
        public async Task<ActionResult> GetProfilePicture(int )
        {

        }*/
    }



}

