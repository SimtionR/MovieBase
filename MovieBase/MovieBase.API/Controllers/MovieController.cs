using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.ResponseModels;
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
        private readonly IMapper _mapper;

        public MovieController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator; 
            _mapper = mapper;
        }

        [HttpGet]
        [Route("movies")]
        public async Task<IEnumerable<MovieResponseModel>> GetMovies()
        {
            var result = await _mediator.Send(new GetAllMoviesQuery());

            var movieResponseList = new List<MovieResponseModel>();
            
            foreach(var movie in result)
            {
                var movieResponse = _mapper.Map<MovieResponseModel>(movie);
                movieResponseList.Add(movieResponse);
            }

            return movieResponseList;
           
        }
        [HttpGet]
        [Route("movieId/{movieId}")]
        public async Task<ActionResult<MovieResponseModel>> GetMovieById(int movieId)
        {
            var result = await _mediator.Send(new GetMovieByIdQuery { MovieId = movieId});
            if (result != null)
                return _mapper.Map<MovieResponseModel>(result);

            return NotFound();
        }

        [HttpPost]
        [Route("addMovie")]
        public async Task<ActionResult<MovieResponseModel>> AddMovie(MovieRequestModel movieModel)
        {
            
            var movieCommand = _mapper.Map<AddMovieCommand>(movieModel);

            var result = await _mediator.Send(movieCommand);
            var movieResposne = _mapper.Map<MovieResponseModel>(result);
            if (movieResposne == null)
                return BadRequest();

            return movieResposne;

        }

       

        


        [HttpGet]
        [Route("recommandation")]
        public async Task<ActionResult<MovieResponseModel>> RecommandMovie()
        {
            #region
            MovieDetails md1 = new MovieDetails { MetaScore = 8.6, UserRating = 7.5 };
            MovieDetails md2 = new MovieDetails { MetaScore = 8.6, UserRating = 7.5 };
            MovieDetails md3 = new MovieDetails { MetaScore = 8.6, UserRating = 7.5 };


            Movie m1 = new Movie { Name = "A1", TypeOf = "Drama", MovieDetails = md1 };
            Movie m2 = new Movie { Name = "A2", TypeOf = "Romance", MovieDetails = md2 };
            Movie m3 = new Movie { Name = " A3", TypeOf = "Drama", MovieDetails = md3 };



            MovieDetails mdW1 = new MovieDetails { MetaScore = 8.6, UserRating = 7.0 };
            MovieDetails mdW2 = new MovieDetails { MetaScore = 8.3, UserRating = 9.0 };
            MovieDetails mdW3 = new MovieDetails { MetaScore = 6.4, UserRating = 5.7 };


            Movie m1WatchList = new Movie { Name = "B1", TypeOf = "Crime", MovieDetails = mdW1 };
            Movie m2WatchList = new Movie { Name = "B2", TypeOf = "Drama", MovieDetails = mdW2 };
            Movie m3WatchList = new Movie { Name = "B3", TypeOf = "Drama", MovieDetails = mdW3 };

            var profile = new Core.Models.Profile
            {
                UserName = "ILoveMovies",
                Ratings = new List<Movie> { m1, m2, m3 },
                WatctList = new List<Movie> { m1WatchList, m2WatchList, m3WatchList },

            };

            var userPreferences = new UserPreferences();
            #endregion


            try
            {
                var movie = await _mediator.Send(new GetMovieByRecommandationQuery
                { profile = profile, userPreferences = userPreferences });
                return _mapper.Map<MovieResponseModel>(movie);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    
        /*
       [HttpPost]
       [Route("addMovieDetails")]
       public async Task<ActionResult> AddMovieDetails(int movieId, MovieDetailsRequestModel model)
       {
           var movie = await _mediator.Send(new GetMovieByIdQuery { MovieId = movieId });



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
              Movie= movie,
              MovieId= movie.Id,
              MetaScore= model.MetaScore,
              UserRating= model.UserRating,
              Actors = listOfActors,


           };

           var command = new AddMovieDetailsCommand() { NewMovieDetails = detailsToAdd, ListOfActorsId= model.ActorsId, ListOfGenresId=model.GenresId};
           var result = await _mediator.Send(command);

           return Ok(result);



       }*/

    }
}
