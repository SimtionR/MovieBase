using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands
{
    public class AddActorCommand : IRequest<Actor>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public int Age { get; set; }
    }
}
