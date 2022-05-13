using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Queries.IdentityQueries
{
    public class GetUserByUserIdQuery : IRequest<User>
    {
        public string UserId { get; set; }
    }
}
