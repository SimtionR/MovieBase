using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands
{
    public class AddPersonalDetailsCommand : IRequest<PersonalDetails>
    {
        //public PersonalDetails NewPersonalDetails { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public string Birthdate { get; set; }
        public string History { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
