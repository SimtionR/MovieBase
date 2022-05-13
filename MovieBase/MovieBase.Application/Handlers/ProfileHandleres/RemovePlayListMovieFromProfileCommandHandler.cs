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
    public class RemovePlayListMovieFromProfileCommandHandler : IRequestHandler<RemovePlayListMovieFromProfileCommand, bool>
    {
        private readonly IProfileRepository _repo;

        public RemovePlayListMovieFromProfileCommandHandler(IProfileRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(RemovePlayListMovieFromProfileCommand request, CancellationToken cancellationToken)
        {
            var isRemoved = await _repo.RemoveFromPlayList(request.MovieId, request.UserId);

            if(isRemoved)
            {
                return true;
            }

            return false;
        }
    }
}
