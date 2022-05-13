using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands.ProfileCommands
{
    public class RemovePlayListMovieFromProfileCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }

    }
}
