using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Queries.ActorQueries
{
    public class GetActorsBySearchQuery : IRequest<IEnumerable<Actor>>
    {
        public string Search { get; set; }
    }
}
