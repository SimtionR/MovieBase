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
    public class GetProfileByProfileIdQueryHandler : IRequestHandler<GetProfileByProfileIdQuery, Profile>
    {
        private readonly IProfileRepository _repo;
        public GetProfileByProfileIdQueryHandler(IProfileRepository repo)
        {
            _repo = repo;
        }
        public async Task<Profile> Handle(GetProfileByProfileIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _repo.GetProfileByProfileId(request.profileId);
            return profile;
        }
    }
}
