using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.API.RequestModels;
using MovieBase.Application.Commands;
using MovieBase.Application.Queries;
using MovieBase.Core.Models;
using MovieBase.Core.RequestModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    public class ActorController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ActorController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getActors")]
        public async Task<IEnumerable<ActorResponseModel>> GetActors()
        {
            var result = await _mediator.Send(new GetAllActorsQuery());
            var responseModels = new List<ActorResponseModel>();
            foreach(var actor in result)
            {
                var responseModel = _mapper.Map<ActorResponseModel>(actor);
                responseModels.Add(responseModel);
            }

            return responseModels;
        }
     
        [HttpGet]
        [Route("actorId/{actorId}")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<ActorResponseModel>> GetActorById(int actorId)
        {
            var result = await _mediator.Send(new GetActorByIdQuery { ActorId = actorId });
            if (result == null)
                return NotFound();

            return _mapper.Map<ActorResponseModel>(result);
        }

        [HttpPost]
        [Route("addActor")]
        public async Task<ActionResult<ActorResponseModel>> AddActor(ActorRequestModel actorModel)
        {
            

            var addActorCommand = _mapper.Map<AddActorCommand>(actorModel);
   
            var result = await _mediator.Send(addActorCommand);
 

            if (result == null)
                return BadRequest(result);

            return _mapper.Map<ActorResponseModel>(result);
        }




        /*[HttpPost]
        [Route("addPersonalDetails/{actorId}")]
        public async Task<ActionResult<PersonalDetails>> AddActorPersonalDetails(int actorId, PersonalDetailsRequestModel personalDetailsModel)
        {
            *//*var actor = await _mediator.Send(new GetActorByIdQuery() { ActorId = actorId });

            if (actor == null)
                return NotFound();


            

            var detailsToAdd = _mapper.Map<PersonalDetails>(personalDetailsModel);
            detailsToAdd.Actor = actor;
            detailsToAdd.ActorId = actor.Id;

            var command = new AddPersonalDetailsCommand() { NewPersonalDetails = detailsToAdd };
            var result = await _mediator.Send(command);

            return result;*//*
            return null;


           

        }*/

    }
}
