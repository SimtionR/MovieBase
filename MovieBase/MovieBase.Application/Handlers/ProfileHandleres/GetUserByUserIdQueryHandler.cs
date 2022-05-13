using MediatR;
using MovieBase.Application.Queries.IdentityQueries;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.ProfileHandleres
{
    public class GetUserByUserIdQueryHandler : IRequestHandler<GetUserByUserIdQuery, User>
    {
        private readonly IIdentityRepository _repo;
        public GetUserByUserIdQueryHandler(IIdentityRepository repo)
        {
            _repo = repo;
        }
        public async Task<User> Handle(GetUserByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetUserByUserId(request.UserId);
        }
    }
}
