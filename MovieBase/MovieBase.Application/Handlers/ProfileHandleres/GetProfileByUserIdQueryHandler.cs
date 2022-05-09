using MediatR;
using MovieBase.Application.Queries;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers
{
    public class GetProfileByUserIdQueryHandler : IRequestHandler<GetProfileByUserIdQuery, Profile>
    {
        private readonly IProfileRepository _repo;

        public GetProfileByUserIdQueryHandler(IProfileRepository repo)
        {
            _repo = repo;
        }
        public async Task<Profile> Handle(GetProfileByUserIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _repo.GetProfileByUserId(request.userId);
            return profile;
        }
    }
}
