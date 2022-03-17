using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBase.Application.Commands;
using MovieBase.Application.Queries;
using MovieBase.Core.Models;
using MovieBase.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    public class MovieController: ApiController
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpGet]
        [Route("movies")]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var result = await _mediator.Send(new GetAllMoviesQuery());
            return result;
        }

        [HttpPost]
        [Route("addMovie")]
        public async Task<ActionResult> AddMovie(MovieRequestModel movie)
        {
            Movie movieToAdd = new Movie
            {
                Name = movie.Name,
                MoviePhoto = movie.MoviePhoto,
                Description = movie.Description,
                Duration = movie.Duration,
                TypeOf = movie.TypeOf,
                MetaScore = movie.MetaScore,
                UserRating = movie.UserRating
            };
            var command = new AddMovieCommand() { NewMovie=movieToAdd};
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
