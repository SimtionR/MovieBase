using MediatR;
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
    public class AddActorCommandHandler : IRequestHandler<AddActorCommand, Actor>
    {
        private readonly MovieBaseDbContext _ctx;

        public AddActorCommandHandler(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Actor> Handle(AddActorCommand request, CancellationToken cancellationToken)
        {

            _ctx.Actors.Add(request.NewActor);
            await _ctx.SaveChangesAsync();
            return request.NewActor;
        }
    }
}
