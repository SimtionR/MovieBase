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
    public class GetValidUserQueryHandler : IRequestHandler<GetValidUserQuery, User>
    {
        private readonly IIdentityRepository _repo;
        public GetValidUserQueryHandler(IIdentityRepository repo)
        {
            _repo = repo;
        }
        public async Task<User> Handle(GetValidUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return null;
            }

            var isValidPasasword = await _repo.CheckPasswordAsync(user, request.Password);
            if (!isValidPasasword)
            {
                return null;
            }

            return user;

        }
    }
}
