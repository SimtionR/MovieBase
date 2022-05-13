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
    public class AddPlayListMovieToProfileCommandHandler : IRequestHandler<AddPlayListMovieToProfileCommand, bool>
    {
        private readonly IProfileRepository _repo;
        public AddPlayListMovieToProfileCommandHandler(IProfileRepository repo)
        {
            _repo = repo;   
        }
        public async Task<bool> Handle(AddPlayListMovieToProfileCommand request, CancellationToken cancellationToken)
        {
            var isAdded = await _repo.AddToPlayList(request.MovieId, request.UserId);
            
            if(isAdded)
            {
                return true;
            }

            return false;
        }
    }
}
