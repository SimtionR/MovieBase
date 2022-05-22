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
    public class AddAcceptedConnectionPendingCommandHandler : IRequestHandler<AddAcceptedConnectionPendingCommand, ResponsePending>
    {
        private readonly IConnectionRepository _repo;
        private readonly IMapper _mapper;
        public AddAcceptedConnectionPendingCommandHandler(IConnectionRepository repo, IMapper mapper)
        {
            _repo = repo; 
            _mapper = mapper;
        }
        public async Task<ResponsePending> Handle(AddAcceptedConnectionPendingCommand request, CancellationToken cancellationToken)
        {
            var responsePending = _mapper.Map<ResponsePending>(request);
            return  await _repo.AcceptConnectionPendingAsync(responsePending);
        }
    }
}
