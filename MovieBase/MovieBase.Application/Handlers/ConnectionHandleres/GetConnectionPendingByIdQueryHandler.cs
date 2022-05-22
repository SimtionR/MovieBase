using MediatR;
using MovieBase.Application.Queries.ConnectionQueries;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.ConnectionHandleres
{
    public class GetConnectionPendingByIdQueryHandler : IRequestHandler<GetConnectionPendingByIdQuery, ConnectionPending>
    {
        private readonly IConnectionRepository _repo;
        public GetConnectionPendingByIdQueryHandler(IConnectionRepository repo)
        {
            _repo = repo;
        }
        public async Task<ConnectionPending> Handle(GetConnectionPendingByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetConnectionPendingByIdAsync(request.ConnectionPendingId);
        }
    }
}
