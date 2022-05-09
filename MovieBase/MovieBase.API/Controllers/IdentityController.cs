using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieBase.API.Contracts.RequestModels;
using MovieBase.Application.Commands;
using MovieBase.Application.Queries;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IOptions<ApplicationSettings> _appSettings;

        public IdentityController(IOptions<ApplicationSettings> appSettings, IMediator mediator)
        {
            _mediator = mediator;
            _appSettings = appSettings;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _mediator.Send(new AddUserCommand { User = user, Password = model.Password });
            if(result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<object>> Login(LoginRequestModel model)
        {
           

            var user = await _mediator.Send(new GetValidUserQuery {UserName = model.UserName, Password = model.Password});

            if(user == null)
            {
                return Unauthorized();
            }

            if(user.Profile == null)
            {
                var profile = await _mediator.Send(new AddProfileCommand { User = user });
                if (profile == null)
                    return BadRequest();
            }

            var result = await _mediator.Send
                (new LoginUserCommand { Secret = _appSettings.Value.Secret, UserId = user.Id.ToString() });

            return result;
        }

    }
}
