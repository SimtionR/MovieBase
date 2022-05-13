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
    public class RemoveWatchListMovieFromProfileCommandHandler : IRequestHandler<RemoveWatchListMovieFromProfileCommand, bool>
    {
        private readonly IProfileRepository _repo;
        public RemoveWatchListMovieFromProfileCommandHandler(IProfileRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(RemoveWatchListMovieFromProfileCommand request, CancellationToken cancellationToken)
        {
            var isRemoved = await _repo.RemoveFromWatchList(request.MovieId, request.UserId);

            if(isRemoved)
            {
                return true;
            }

            return false;
        }
    }
}
