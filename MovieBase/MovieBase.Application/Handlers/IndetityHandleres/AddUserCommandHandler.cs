using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieBase.Application.Commands;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, IdentityResult>
    {
        private readonly IIdentityRepository _repo;

        public AddUserCommandHandler(IIdentityRepository repo)
        {
            _repo = repo;
        }
        public async Task<IdentityResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var identityResult = await _repo.CreateUserAsync(request.User, request.Password);

            return identityResult;
        }
    }
}
