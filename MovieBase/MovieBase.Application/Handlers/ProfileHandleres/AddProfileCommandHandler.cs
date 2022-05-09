using MediatR;
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
    public class AddProfileCommandHandler : IRequestHandler<AddProfileCommand, Profile>
    {
        private readonly IProfileRepository _repo;
        public AddProfileCommandHandler(IProfileRepository repo)
        {
            _repo = repo;
        }
        public async Task<Profile> Handle(AddProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _repo.CreateProfileAsync(request.User);
            return profile;
        }
    }
}
