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
    public class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQuery, IEnumerable<Actor>>
    {
        private readonly MovieBaseDbContext _ctx;

        public GetAllActorsQueryHandler(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Actor>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
        {
            return await _ctx.Actors.Include(actor => actor.PersonalDetails).ToListAsync();
            
        }
    }
}
