using MediatR;
using MovieBase.Application.Queries.ProfileQueries;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.ProfileHandleres
{
    public class GetProfileBySearchQueryHandler : IRequestHandler<GetProfilesBySearchQuery, IEnumerable<Profile>>
    {
        private readonly IProfileRepository _repo;
        public GetProfileBySearchQueryHandler(IProfileRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Profile>> Handle(GetProfilesBySearchQuery request, CancellationToken cancellationToken)
        {
            var profiles = await _repo.GetProfilesBySearchAsync(request.Search);

            return profiles;
        }
    }
}
