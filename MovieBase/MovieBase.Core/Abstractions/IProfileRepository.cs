using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Abstractions
{
    public interface IProfileRepository
    {
        Task<Profile> CreateProfileAsync(User user);
        Task<Profile> GetProfileByUserId(string userId);
        Task<Profile> GetProfileByProfileId(int profileId);
        Task<bool> UpdateProfilePicture(string userId);
    }
}
