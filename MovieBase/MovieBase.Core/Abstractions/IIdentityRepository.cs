using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MovieBase.API;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Abstractions
{
    public interface IIdentityRepository
    {
        Task<object> LoginUser(string secret, string userId);
        Task<User> FindByNameAsync(string username);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<User> GetUserByUserId(string userId);  
        //Task<IEnumerable<User>> GetUsersBySearch(string search);
    }
}
