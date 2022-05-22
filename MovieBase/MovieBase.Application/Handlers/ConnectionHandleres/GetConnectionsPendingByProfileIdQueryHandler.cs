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
    public class GetConnectionsPendingByProfileIdQueryHandler 
        : IRequestHandler<GetConnectionsPendingByProfileIdQuery, IEnumerable<ConnectionPending>>
    {
        private readonly IConnectionRepository _repo;
        public GetConnectionsPendingByProfileIdQueryHandler(IConnectionRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<ConnectionPending>> Handle(GetConnectionsPendingByProfileIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetConnectionsPendingByProfileIdAsync(request.ProfileId);
        }
    }
}
