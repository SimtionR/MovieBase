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
    public class GetConnectionsByProfileIdHandler : IRequestHandler<GetConnectionsByProfileIdQuery, IEnumerable<Connection>>
    {
        private readonly IConnectionRepository _repo;
        public GetConnectionsByProfileIdHandler(IConnectionRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Connection>> Handle(GetConnectionsByProfileIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetConnectionsByProfileId(request.ProfileId);
        }
    }
}
