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
        private IBlobStorageService _blobService;
        private readonly string blobCotnainer = "profilepictures";

        public ProfileController(IMediator mediator, IMapper mapper, IBlobStorageService blobStorageService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _blobService = blobStorageService;
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

        [HttpGet]
        [Route("getProfilePicture/{name}")]
        public async Task<ActionResult> GetProfilePicutre(string name)
        {

            var data = await _blobService.GetBlobAsync(name, blobCotnainer);
            return File(data.Content, data.ContentType);
        }

        [HttpPost]
        [Route("uploadContent")]
        public Task<ActionResult> UploadProfilePicture(IFormFile file)
        {
            return null; 
        }
        [HttpPost]
        [Route("uploadProfilePicture")]
        public async Task<ActionResult> UploadProfilePicture([FromBody] UploadFileRequestModel request)
        {
            await _blobService.UploadFileBlobAsync(request.FilePath, request.FileName, blobCotnainer);
            return Ok();
        }
       
    }
}
