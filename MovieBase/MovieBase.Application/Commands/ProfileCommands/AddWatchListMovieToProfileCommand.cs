using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands.ProfileCommands
{
    public class AddWatchListMovieToProfileCommand : IRequest<bool>
    {
        public int MovieId { get; set; }
        public string UserId { get; set; }
    }
}
