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
    public class GetActorByIdQueryHandler : IRequestHandler<GetActorByIdQuery, Actor>
    {
        private readonly MovieBaseDbContext _ctx;

        public GetActorByIdQueryHandler(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Actor> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _ctx.Actors.Include(actor=> actor.PersonalDetails).Where(a => a.Id == request.ActorId).FirstOrDefaultAsync();

        }
    }
}
