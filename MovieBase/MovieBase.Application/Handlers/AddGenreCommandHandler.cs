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
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, Genre>
    {
        private readonly IGenreRepository _repo;
        private readonly IMapper _mapper;

        public AddGenreCommandHandler(IGenreRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Genre> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = _mapper.Map<Genre>(request);

            return await _repo.CreateGenreAsync(genre);
        }
    }
}
