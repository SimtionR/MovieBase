using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.API.RequestModels;
using MovieBase.Application.Commands;
using MovieBase.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    public class MovieDetailsController : ApiController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MovieDetailsController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper; 
            _mediator = mediator;
        }

        [HttpGet]
        [Route("movieDetails/{movieId}")]
        public async Task<ActionResult<MovieDetailsResponseModel>> GetMovieDetailsByMovieId(int movieId)
        {
            var result = await _mediator.Send(new GetMovieDetailsByMovieQuery() { MovieId = movieId });
            if (result == null)
                return BadRequest();

            return _mapper.Map<MovieDetailsResponseModel>(result);
        }


        [HttpPost]
        [Route("addMovieDetails")]
        public async Task<ActionResult<MovieDetailsResponseModel>> AddMovieDetails(MovieDetailsRequestModel model)
        {
            /*  var movie = await _mediator.Send(new GetMovieByIdQuery { MovieId = movieId });



              if (movie == null)
                  return BadRequest();

              var listOfActors = new List<Actor>();
              var listOfGenres = new List<Genre>();

              foreach (var actor in model.ActorsId)
              {
                  var actorToAdd = await _mediator.Send(new GetActorByIdQuery { ActorId = actor });
                  if (actorToAdd == null)
                      return BadRequest();

                  listOfActors.Add(actorToAdd);

              }
              foreach (var genre in model.GenresId)
              {
                  var genreToAdd = await _mediator.Send(new GetGenreByIdQuery { GenreId = genre });
                  if (genreToAdd == null)
                      return BadRequest();

                  listOfGenres.Add(genreToAdd);

              }

              MovieDetails detailsToAdd = new MovieDetails
              {
                  Movie = movie,
                  MovieId = movie.Id,
                  MetaScore = model.MetaScore,
                  UserRating = model.UserRating,
                  Actors = listOfActors,


              };

              var command = new AddMovieDetailsCommand() { NewMovieDetails = detailsToAdd, ListOfActorsId = model.ActorsId, ListOfGenresId = model.GenresId };
              var result = await _mediator.Send(command);

              return Ok(result);*/


            var movie = await _mediator.Send(new GetMovieByIdQuery { MovieId = model.MovieId });



            if (movie == null)
                return BadRequest();

            var movieDetailsCommand = _mapper.Map<AddMovieDetailsCommand>(model);
            var result = await _mediator.Send(movieDetailsCommand);

            if (result == null)
                return BadRequest();

            return _mapper.Map<MovieDetailsResponseModel>(result);

        }
    }
}
