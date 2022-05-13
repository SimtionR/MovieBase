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
    public class UserReviewRepository : IUserReviewRepository
    {
        private readonly MovieBaseDbContext _ctx;
        public UserReviewRepository(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<UserReview> CreateUserReviewAsync(UserReview userReview)
        {
            var movieDetails = await _ctx.MovieDetails.Where(m => m.MovieId == userReview.MovieId).FirstOrDefaultAsync();
            if (movieDetails == null)
            {
                throw new Exception("Can't be added because Movie details is not ready");
                
            }

            _ctx.UserReviews.Add(userReview);
            await _ctx.SaveChangesAsync();

            movieDetails.UsersReview.Add(userReview);
            await _ctx.SaveChangesAsync();

            return userReview;
        }

        public Task<bool> DeleteUserReviewAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditRatingAsync(double rating)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditReviewComment(string comment)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserReview>> GetAllReviewsByMovieIdAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserReview> GetReviewByIdAsync(int reviewId)
        {
            var review = await _ctx.UserReviews.Where(r => r.Id == reviewId).FirstOrDefaultAsync();
            return review;
        }

        public Task<IEnumerable<UserReview>> GettAllReviewsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReactToReviewe(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
