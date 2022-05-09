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
    public class GetPersonalDetailsByActorQueryHandler : IRequestHandler<GetPersonalDetailsByActorQuery, PersonalDetails>
    {
        private readonly IPersonalDetailsRepository _repo;

        public GetPersonalDetailsByActorQueryHandler(IPersonalDetailsRepository repo)
        {
            _repo = repo;
        }
        public Task<PersonalDetails> Handle(GetPersonalDetailsByActorQuery request, CancellationToken cancellationToken)
        {
            var personalDetails = _repo.GetPersonalDetailsAsync(request.ActorId);
            return personalDetails;
        }
    }
}
