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

        public ActorController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<Actor> AddActor(ActorRequestModel actor)
        {
            var actorToAdd = new Actor
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Age = actor.Age
            };

            var command = new AddActorCommand() { NewActor = actorToAdd };
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpPost]
        [Route("addPersonalDetails/{actorId}")]
        public async Task<ActionResult<PersonalDetails>> AddActorPersonalDetails(int actorId, PersonalDetailsRequestModel personalDetails)
        {
            var actor = await _mediator.Send(new GetActorByIdQuery() { ActorId = actorId });

            if (actor == null)
                return NotFound();


            var detailsToAdd = new PersonalDetails
            {
                Actor = actor,
                ActorId = actorId,
                Birthdate = personalDetails.Birthdate,
                City = personalDetails.City,
                Country = personalDetails.Country,
                History = personalDetails.History,
            };

            var command = new AddPersonalDetailsCommand() { NewPersonalDetails = detailsToAdd };
            var result = await _mediator.Send(command);

            return result;


           

        }

    }
}
