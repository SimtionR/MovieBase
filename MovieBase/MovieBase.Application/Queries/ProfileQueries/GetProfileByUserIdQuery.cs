using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Queries
{
    public class GetProfileByUserIdQuery : IRequest<Profile>
    {
        public string userId { get; set; }
    }
}
