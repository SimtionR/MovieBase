using MediatR;
using MovieBase.Application.Queries;
using MovieBase.Application.Queries.ActorQueries;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.ActorHandleres
{
    public class GetActorsBySearchQueryHandler : IRequestHandler<GetActorsBySearchQuery, IEnumerable<Actor>>
    {
        private readonly IActorRepository _repo;
        public GetActorsBySearchQueryHandler(IActorRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Actor>> Handle(GetActorsBySearchQuery request, CancellationToken cancellationToken)
        {
            var actors = await _repo.GetActorsBySearchAsync(request.Search);

            return actors;
        }
    }
}
