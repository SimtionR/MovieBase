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
    public class AddActorCommandHandler : IRequestHandler<AddActorCommand, Actor>
    {
        private readonly IActorRepository _repo;
        private readonly IMapper _mapper;

        public AddActorCommandHandler(IActorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Actor> Handle(AddActorCommand request, CancellationToken cancellationToken)
        {

            
            var actor = _mapper.Map<Actor>(request);

            return await _repo.CreateActorAsync(actor);
        }
    }
}
