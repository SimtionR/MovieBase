using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Queries.ConnectionQueries
{
    public class GetConnectionsPendingByProfileIdQuery : IRequest<IEnumerable<ConnectionPending>>
    {
        public int ProfileId { get; set; }
    }
}
