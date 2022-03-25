using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands
{
    public class AddGenreCommand : IRequest<Genre>
    {
        public Genre NewGenre { get; set; }
    }
}
