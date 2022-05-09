using MediatR;
using MovieBase.Application.Commands;
using MovieBase.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, object>
    {
        public readonly IIdentityRepository _repo;

        public LoginUserCommandHandler(IIdentityRepository repo)
        {
            _repo = repo;
        }
        public async Task<object> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _repo.LoginUser(request.Secret, request.UserId);
            return result;
        }
    }
}
