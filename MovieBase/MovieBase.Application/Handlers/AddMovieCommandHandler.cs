using AutoMapper;
using MediatR;
using MovieBase.Application.Commands;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using MovieBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, Movie>
    {
        private readonly IMovieRepository _repo;
        private readonly IMapper _mapper;
        public AddMovieCommandHandler(IMovieRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Movie> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Movie>(request);

            return await _repo.CreateMovieAsync(movie);
            
        }
    }
}
