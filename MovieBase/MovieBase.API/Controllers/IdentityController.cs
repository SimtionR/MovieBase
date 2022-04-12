using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieBase.API.Contracts.RequestModels;
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
        private readonly UserManager<User> _userMananger;
        private readonly IOptions<ApplicationSettings> _appSettings;

        public IdentityController(UserManager<User> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _userMananger = userManager;
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

            var result = await _userMananger.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);    
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(LoginRequestModel model)
        {
            var user = await _userMananger.FindByNameAsync(model.UserName);
            if(user == null)
            {
                return Unauthorized();
            }

            var passwordIsValid = await _userMananger.CheckPasswordAsync(user, model.Password);

            if(!passwordIsValid)
            {
                return Unauthorized();
            }    
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }

    }
}
