using AutoMapper;
using MediatR;
using MovieBase.Application.Commands.ConnectionCommands;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.ConnectionHandleres
{
    public class AddDeclienedConnectionPendingCommandHandler : IRequestHandler<AddDeclinedConnectionPendingCommand, ResponsePending>
    {
        private readonly IConnectionRepository _repo;
        private readonly IMapper _mapper;
        public AddDeclienedConnectionPendingCommandHandler(IConnectionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ResponsePending> Handle(AddDeclinedConnectionPendingCommand request, CancellationToken cancellationToken)
        {
            var resposnePending = _mapper.Map<ResponsePending>(request);
            return await _repo.DeclineConnectionPendingAsync(resposnePending);
        }
    }
}
