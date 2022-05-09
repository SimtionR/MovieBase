using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Queries
{
    public class GetMovieByRecommandationQuery : IRequest<Movie>
    {
        public UserPreferences userPreferences { get; set; }
        public Profile profile { get; set; }
    }
}
