using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Queries.ConnectionQueries
{
    public class GetConnectionPendingByIdQuery : IRequest<ConnectionPending>
    {
        public int ConnectionPendingId { get; set; }
    }
}
