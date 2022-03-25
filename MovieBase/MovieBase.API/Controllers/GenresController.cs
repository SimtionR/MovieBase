using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.RequestModels;
using MovieBase.Application.Commands;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    public class GenresController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GenresController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;   
            _mapper = mapper;
        }


        [HttpGet]
        [Route("getGenre/{genreId}")]
        public async Task<ActionResult> GetGenreById(int genreId)
        {
            return null;
        }
        [HttpPost]
        [Route("addGenre")]
        public async Task<ActionResult> AddGenre(GenreRequestModel genreModel)
        {
            
            
           /* Genre genreToAdd = new Genre
            {
                Description = model.Description,
                Name = model.Name
            };*/

            var genreToAdd = _mapper.Map<Genre>(genreModel);

            var command = new AddGenreCommand() { NewGenre = genreToAdd };
            var result = await _mediator.Send(command);

            return Ok(result);

        }
    }
}
