using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieBase.Application.Queries;
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
    public class GetActorByIdQueryHandler : IRequestHandler<GetActorByIdQuery, Actor>
    {
        private readonly IActorRepository _repo;

        public GetActorByIdQueryHandler(IActorRepository repo)
        {
            _repo = repo;
        }

        public async Task<Actor> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetActorByIdAsync(request.ActorId);

        }
    }
}
