using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieBase.Application.Queries;
using MovieBase.Core.Models;
using MovieBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private readonly MovieBaseDbContext _ctx;

        public GetMovieByIdQueryHandler(MovieBaseDbContext ctx)
        {
            _ctx = ctx; 
        }

        public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _ctx.Movies.Where(m => m.Id == request.MovieId).FirstOrDefaultAsync();
        }

      

    }
}
