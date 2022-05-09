using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands
{
    public class LoginUserCommand : IRequest<object>
    {
        public string Secret;
        public string UserId;
    }
}
