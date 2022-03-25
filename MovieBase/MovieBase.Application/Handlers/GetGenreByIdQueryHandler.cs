using MediatR;
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
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Genre>
    {
        private readonly MovieBaseDbContext _ctx;

        public GetGenreByIdQueryHandler(MovieBaseDbContext ctx)
        {
            _ctx = ctx; 
        }
        public async Task<Genre> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
