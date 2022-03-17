using MediatR;
using MovieBase.Application.Commands;
using MovieBase.Core.Models;
using MovieBase.Core.RequestModels;
using MovieBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, Movie>
    {
        private readonly MovieBaseDbContext _ctx;

        public AddMovieCommandHandler(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Movie> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
         

            _ctx.Movies.Add(request.NewMovie);
            await _ctx.SaveChangesAsync();

            return request.NewMovie;
        }
    }
}
