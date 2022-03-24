using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieBase.Application.Commands;
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
        private readonly MovieBaseDbContext _ctx;

        public AddMovieDetailsCommandHandler(MovieBaseDbContext ctx)
        {
            _ctx= ctx;
        }

        public async Task<MovieDetails> Handle(AddMovieDetailsCommand request, CancellationToken cancellationToken)
        {
            _ctx.MovieDetails.Add(request.NewMovieDetails);
            var movie = await _ctx.Movies.Where(m => m.Id == request.NewMovieDetails.MovieId).FirstOrDefaultAsync();
            _ctx.Movies.Update(movie).Entity.MovieDetailsId = request.NewMovieDetails.Id;

            _ctx.SaveChangesAsync();

            return request.NewMovieDetails;

        }
    }
}
