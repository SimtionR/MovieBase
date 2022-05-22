using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Queries.MovieQueries
{
    public class GetMoviesBySearchQuery : IRequest<IEnumerable<Movie>>
    {
        public string Search { get; set; }
    }
}
