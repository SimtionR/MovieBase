using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieBase.Application.Commands;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using MovieBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers
{
    public class AddMovieDetailsCommandHandler : IRequestHandler<AddMovieDetailsCommand, MovieDetails>
    {
        private readonly IMovieDetailsRepository _repo;
        private readonly IMapper _mapper;

        public AddMovieDetailsCommandHandler(IMovieDetailsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            
        }

        public async Task<MovieDetails> Handle(AddMovieDetailsCommand request, CancellationToken cancellationToken)
        {
            /*foreach(var genre in request.ListOfGenresId )
            {

            }

            foreach(var genre in request.ListOfActorsId)
            {

            }

            _ctx.MovieDetails.Add(request.NewMovieDetails);


            var movie = await _ctx.Movies.Where(m => m.Id == request.NewMovieDetails.MovieId).FirstOrDefaultAsync();
            _ctx.Movies.Update(movie).Entity.MovieDetailsId = request.NewMovieDetails.Id;
            _ctx.Movies.Update(movie);

            _ctx.SaveChangesAsync();

            return request.NewMovieDetails;*/

            var personalDetails = _mapper.Map<MovieDetails>(request);
            return await _repo.CreateMovieDetailsAsync(personalDetails, request.ActorsId, request.GenresId);

        }
    }
}
