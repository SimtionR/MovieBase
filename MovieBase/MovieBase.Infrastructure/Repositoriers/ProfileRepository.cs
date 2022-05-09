using Microsoft.EntityFrameworkCore;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Repositoriers
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly MovieBaseDbContext _ctx;
        public ProfileRepository(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Profile> CreateProfileAsync(User user)
        {
            var profile = new Profile
            {
                User = user,
                UserId = user.Id,
                UserName = user.UserName
            };

            _ctx.Profiles.Add(profile);
            await _ctx.SaveChangesAsync();
            
            var userToUpdate = await _ctx.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            _ctx.Update(userToUpdate.Profile = profile);
            //_ctx.Update(userToUpdate.ProfileId = profile.Id);
            await _ctx.SaveChangesAsync();

            return profile;
        }

        public async Task<Profile> GetProfileByProfileId(int profileId)
        {
            var profile = await _ctx.Profiles.Where(p => p.Id == profileId).FirstOrDefaultAsync();
            return profile;
        }

        public async Task<Profile> GetProfileByUserId(string userId)
        {
            var profile = await _ctx.Profiles.Where(p => p.UserId == userId).FirstOrDefaultAsync();
            return profile;
        }

        public async Task<bool> UpdateProfilePicture(string userId)
        {
            /*var profileToUpdate = await GetProfileByUserId(userId);

            _ctx.Profiles.Update(profileToUpdate.ProfilePictureName)*/

            return false;


        }
    }
}
