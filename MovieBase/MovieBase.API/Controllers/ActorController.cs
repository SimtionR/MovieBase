using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<Actor>> GetActors()
        {
            var result = await _mediator.Send(new GetAllActorsQuery());
            return result;
        }

        [HttpGet]
        [Route("actorId/{actorId}")]
        public async Task<ActionResult<Actor>> GetActorById(int actorId)
        {
            var result = await _mediator.Send(new GetActorByIdQuery { ActorId = actorId });
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        [Route("addActor")]
        public async Task<Actor> AddActor(ActorRequestModel actorModel)
        {
            /*var actorToAdd = new Actor
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Age = actor.Age
            };*/
            var actorToAdd = _mapper.Map<Actor>(actorModel);
            var command = new AddActorCommand() { NewActor = actorToAdd };
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpPost]
        [Route("addPersonalDetails/{actorId}")]
        public async Task<ActionResult<PersonalDetails>> AddActorPersonalDetails(int actorId, PersonalDetailsRequestModel personalDetailsModel)
        {
            var actor = await _mediator.Send(new GetActorByIdQuery() { ActorId = actorId });

            if (actor == null)
                return NotFound();


            /*var detailsToAdd = new PersonalDetails
            {
                Actor = actor,
                ActorId = actorId,
                Birthdate = personalDetails.Birthdate,
                City = personalDetails.City,
                Country = personalDetails.Country,
                History = personalDetails.History,
            };*/

            var detailsToAdd = _mapper.Map<PersonalDetails>(personalDetailsModel);
            detailsToAdd.Actor = actor;
            detailsToAdd.ActorId = actor.Id;

            var command = new AddPersonalDetailsCommand() { NewPersonalDetails = detailsToAdd };
            var result = await _mediator.Send(command);

            return result;


           

        }

    }
}
