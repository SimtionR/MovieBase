using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.RequestModels;
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
        [HttpGet]
        [Route("movieId/{movieId}")]
        public async Task<ActionResult<Movie>> GetMovieById(int movieId)
        {
            var result = await _mediator.Send(new GetMovieByIdQuery { MovieId = movieId});
            if (result != null)
                return result;

            return NotFound();
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
                TypeOf = movie.TypeOf      
            };

            var command = new AddMovieCommand() { NewMovie=movieToAdd};
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("addMovieDetails")]
        public async Task<ActionResult> AddMovieDetails(int movieId, MovieDetailsRequestModel model)
        {
            var movie = await _mediator.Send(new GetMovieByIdQuery { MovieId = movieId });

            if (movie == null)
                return BadRequest();

            MovieDetails detailsToAdd = new MovieDetails
            {
               Movie= movie,
               MovieId= movie.Id,
               MetaScore= model.MetaScore,
               UserRating= model.UserRating,    
               Genres= model.Genres,
               Actors= model.Actors
            };

            var command = new AddMovieDetailsCommand() { NewMovieDetails = detailsToAdd };
            var result = await _mediator.Send(command);

            return Ok(result);


            
        }

    }
}
