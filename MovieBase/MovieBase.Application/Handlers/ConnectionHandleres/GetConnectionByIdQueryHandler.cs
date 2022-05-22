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
    public class GetConnectionByIdQueryHandler : IRequestHandler<GetConnectionByIdQuery, Connection>
    {
        private readonly IConnectionRepository _repo;
        public GetConnectionByIdQueryHandler(IConnectionRepository repo)
        {
            _repo = repo;
        }
        public async Task<Connection> Handle(GetConnectionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetConnectionByIdAsync(request.ConnectionId);
        }
    }
}
