using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Queries
{
    public class GetGenreByIdQuery : IRequest<Genre>
    {
        public int GenreId { get; set; }
    }
}
