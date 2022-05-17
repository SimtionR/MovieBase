using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Abstractions
{
    public interface IUserReviewRepository
    {
        Task<UserReview> CreateUserReviewAsync(UserReview userReview);
        Task<bool> DeleteUserReviewAsync();
        Task<bool> EditRatingAsync(double rating);
        Task<bool> EditReviewComment(string comment);
        Task<bool> ReactToReviewe(int reviewId);
        Task<UserReview> GetReviewByIdAsync(int reviewId);
        Task<IEnumerable<UserReview>> GettAllReviewsByUserIdAsync(string userId);
        Task<IEnumerable<UserReview>> GetAllReviewsByMovieIdAsync(int movieId);
        Task<IEnumerable<UserReview>> GetAllReviewsMyMovieDetailsIdAsync(int movieDetails);
    }
}
