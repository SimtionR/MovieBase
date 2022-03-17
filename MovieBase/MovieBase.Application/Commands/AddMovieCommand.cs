using MediatR;
using MovieBase.Core.Models;
using MovieBase.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands
{
    public class AddMovieCommand : IRequest<Movie>
    {
        public Movie NewMovie { get; set; }
    }
}
