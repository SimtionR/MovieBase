using MediatR;
using MovieBase.Application.Commands.MovieCommands;
using MovieBase.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.MovieHandleres
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly IMovieRepository _repo;
        public DeleteMovieCommandHandler(IMovieRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteMovie(request.MovieId);
        }
    }
}
