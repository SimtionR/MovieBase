using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands.MovieCommands
{
    public class DeleteMovieCommand : IRequest<bool>
    {
        public int MovieId { get; set; }
    }
}
