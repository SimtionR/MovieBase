using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ProfileRepository : IProfileRepository
    {
        private readonly MovieBaseDbContext _ctx;
        private readonly IMovieRepository _movieRepository;
        public ProfileRepository(MovieBaseDbContext ctx, IMovieRepository movieRepository)
        {
            _ctx = ctx;
            _movieRepository = movieRepository;
        }

        public async Task<bool> AddToPlayList(int movieId, string userId)
        {
            var movieToAdd = await _movieRepository.GetMovieByIdAsync(movieId);

            if(movieToAdd == null)
            {
                return false;
            }

            var profileToUpdate = await GetProfileByUserId(userId);

            if (profileToUpdate.PlayList.Contains(movieToAdd))
            {
                return false;
            }

            profileToUpdate.PlayList.Add(movieToAdd);

            await _ctx.SaveChangesAsync();

            return true;


        }

        public async Task<bool> AddToWatchLsit(int movieId, string userId)
        {
            var movieToAdd = await _movieRepository.GetMovieByIdAsync(movieId);

            if (movieToAdd == null)
            {
                return false;
            }

            var profileToUpdate = await GetProfileByUserId(userId);

            if(profileToUpdate.WatctList.Contains(movieToAdd))
            {
                return false;
            }


            profileToUpdate.WatctList.Add(movieToAdd);

            await _ctx.SaveChangesAsync();

            return true;
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
       
            await _ctx.SaveChangesAsync();

            return profile;
        }

        public async Task<Profile> GetProfileByProfileId(int profileId)
        {
            var profile = await _ctx.Profiles.Include(p=> p.WatctList).Include(p => p.PlayList).Where(p => p.Id == profileId).FirstOrDefaultAsync();
            return profile;
        }

        public async Task<Profile> GetProfileByUserId(string userId)
        {
            var profile = await _ctx.Profiles.Include(p => p.WatctList).Include(p => p.PlayList).Where(p => p.UserId == userId).FirstOrDefaultAsync();
            return profile;
        }

        public async Task<bool> RemoveFromPlayList(int movieId, string userId)
        {
            var movieToRemove = await _movieRepository.GetMovieByIdAsync(movieId);

            if(movieToRemove == null)
            {
                return false;
            }

            var profileToUpdate =await GetProfileByUserId(userId);

            if(!profileToUpdate.PlayList.Contains(movieToRemove))
            {
                return false;
            }

            profileToUpdate.PlayList.Remove(movieToRemove);

            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFromWatchList(int movieId, string userId)
        {
            var movieToRemove = await _movieRepository.GetMovieByIdAsync(movieId);

            if (movieToRemove == null)
            {
                return false;
            }

            var profileToUpdate = await GetProfileByUserId(userId);

            if (!profileToUpdate.WatctList.Contains(movieToRemove))
            {
                return false;
            }

            profileToUpdate.WatctList.Remove(movieToRemove);

            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProfilePicture(string userId)
        {
            /*var profileToUpdate = await GetProfileByUserId(userId);

            _ctx.Profiles.Update(profileToUpdate.ProfilePictureName)*/

            return false;


        }
    }
}
