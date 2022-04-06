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
        [Route("getGenreById/{genreId}")]
        public async Task<ActionResult<GenreResponseModel>> GetGenreById(int genreId)
        {
            var result = await _mediator.Send(new GetGenreByIdQuery { GenreId = genreId });
            if (result == null)
                return BadRequest();

            return _mapper.Map<GenreResponseModel>(result);
        }

        [HttpGet]
        [Route("allGenres")]
        public async Task<IEnumerable<GenreResponseModel>> GetAllGenres()
        {
            return null;
        }
        [HttpGet]
        [Route("getGenreByName/{genreName}")]
        public async Task<GenreResponseModel> GetGenreByName(string genreName)
        {
            return null;
        }
        [HttpPost]
        [Route("addGenre")]
        public async Task<ActionResult<GenreResponseModel>> AddGenre(GenreRequestModel genreModel)
        {
            
            
           /* Genre genreToAdd = new Genre
            {
                Description = model.Description,
                Name = model.Name
            };*/

            var genreCommand = _mapper.Map<AddGenreCommand>(genreModel);
           
            var result = await _mediator.Send(genreCommand);

            return Ok(result);

        }
    }
}
