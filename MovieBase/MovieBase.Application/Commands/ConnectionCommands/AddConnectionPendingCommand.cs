using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands.ConnectionCommands
{
    public class AddConnectionPendingCommand : IRequest<ConnectionPending>
    {
        public Profile SenderProfile { get; set; }
        public int ReceiverProfileId { get; set; }
    }
}
