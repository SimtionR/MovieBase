using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieBase.API;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Repositoriers
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<User> _userMananger;
    
        public IdentityRepository(UserManager<User> userManager)
        {
            _userMananger = userManager;
            
        }
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var isValid = await _userMananger.CheckPasswordAsync(user, password);

            return isValid;
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
           var result = await _userMananger.CreateAsync(user, password);
            

            return result;
        }

        public async Task<User> FindByNameAsync(string username)
        {
            var user = await _userMananger.FindByNameAsync(username);
            return user; 
        }

        public async Task<object> LoginUser(string secret, string userId)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return new
            {
                encryptedToken
            };
        }
    }
}
