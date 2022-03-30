using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.API.RequestModels;
using MovieBase.Application.Commands;
using MovieBase.Application.Queries;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    public class ActorDetailsController: ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ActorDetailsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("addPersonalDetails/{actorId}")]
        public async Task<ActionResult<PersonalDetailsResponseModel>> AddActorPersonalDetails(int actorId, PersonalDetailsRequestModel personalDetailsModel)
        {
            var actor = await _mediator.Send(new GetActorByIdQuery() { ActorId = actorId });

            if (actor == null)
                return NotFound();


            var personalDetailsCommand = _mapper.Map<AddPersonalDetailsCommand>(personalDetailsModel);
            personalDetailsCommand.Actor = actor;
            personalDetailsCommand.ActorId = actor.Id;

            
            var result = await _mediator.Send(personalDetailsCommand);

            if (result == null)
                return BadRequest();

            return _mapper.Map<PersonalDetailsResponseModel>(result);


        }

        [HttpGet]
        [Route("personalDetais/{actorId}")]
        public async Task<ActionResult<PersonalDetailsResponseModel>> GetPersonalDetailsByActor(int actorId)
        {
            var personalDetails = await _mediator.Send(new GetPersonalDetailsByActorQuery { ActorId = actorId });
            if (personalDetails == null)
                return BadRequest();

            return _mapper.Map<PersonalDetailsResponseModel>(personalDetails);
        }
    }
}
