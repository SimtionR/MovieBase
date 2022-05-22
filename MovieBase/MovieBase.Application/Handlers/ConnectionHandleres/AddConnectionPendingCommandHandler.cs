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
    public class AddConnectionPendingCommandHandler : IRequestHandler<AddConnectionPendingCommand, ConnectionPending>
    {
        private readonly IConnectionRepository _repo;

        public AddConnectionPendingCommandHandler(IConnectionRepository repo)
        { 
            _repo = repo;        
        }
        public async  Task<ConnectionPending> Handle(AddConnectionPendingCommand request, CancellationToken cancellationToken)
        {
            return await _repo.SendConnectionPendingAsync(request.SenderProfile, request.ReceiverProfileId);
        }
    }
}
