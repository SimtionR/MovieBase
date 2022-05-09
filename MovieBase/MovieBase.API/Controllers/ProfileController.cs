using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.ResponseModels;
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
    public class ProfileController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProfileController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("userProfile")]
        public async Task<ActionResult<ProfileResponseModel>> GetProfileByUserId()
        {
            var claims = this.User.Identities.FirstOrDefault().Claims;
            var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            
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
    }
}
