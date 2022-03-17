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
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<Movie>>
    {
        private readonly MovieBaseDbContext _ctx;

        public GetAllMoviesQueryHandler(MovieBaseDbContext ctx)
        {
            _ctx = ctx; 
        }
        public async Task<List<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            return await  _ctx.Movies.ToListAsync();
        }
    }
}
