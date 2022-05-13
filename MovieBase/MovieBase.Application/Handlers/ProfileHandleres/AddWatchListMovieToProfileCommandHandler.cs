using MediatR;
using MovieBase.Application.Commands.ProfileCommands;
using MovieBase.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.ProfileHandleres
{
    public class AddWatchListMovieToProfileCommandHandler : IRequestHandler<AddWatchListMovieToProfileCommand, bool>
    {
        private readonly IProfileRepository _repo;
        public AddWatchListMovieToProfileCommandHandler(IProfileRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(AddWatchListMovieToProfileCommand request, CancellationToken cancellationToken)
        {
            var isAdded = await _repo.AddToWatchLsit(request.MovieId, request.UserId);
            if(isAdded)
            {
                return true;
            }

            return false;
        }
    }
}
