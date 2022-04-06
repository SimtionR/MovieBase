using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class UserPreferences
    {
        public UserPreferences()
        {

        }
        public string PrefferedType { get; set; }
        public double MetaScoreTaste { get; set; }
        public double UserRatingTaste { get; set; }


        public UserPreferences CalculateUserPreferances(List<Movie> ratings)
        {
            CalculatePrefferedType(ratings);
            CalculateMetaScoreTaste(ratings);
            CalculateUserRatingTaste(ratings);

            return this;

        }

        public bool CheckWatchListForRecommandation(List<Movie> watchlist)
        {
            var isMovieUserRated = watchlist.
                Where(m => m.TypeOf == PrefferedType && m.MovieDetails.UserRating > UserRatingTaste + 0.5)
                .Any();

            var isMovieMetaRated = watchlist
                .Where(m => m.TypeOf == PrefferedType && m.MovieDetails.MetaScore > MetaScoreTaste)
                .Any();

            if (isMovieUserRated || isMovieMetaRated)
                return true;

            return false;
        }

        private void CalculateUserRatingTaste(List<Movie> ratings)
        {
            double userRating = 0;
            foreach (var r in ratings)
            {
                userRating += r.MovieDetails.UserRating;
            }
            userRating = userRating / ratings.Count;
            UserRatingTaste = userRating;
        }

        private void CalculateMetaScoreTaste(List<Movie> ratings)
        {
            double metaScore = 0;
            foreach (var r in ratings)
            {
                metaScore += r.MovieDetails.MetaScore;
            }
            metaScore = metaScore / ratings.Count;
            MetaScoreTaste = metaScore;
        }

        private void CalculatePrefferedType(List<Movie> ratings)
        {

            var typeOf = ratings.GroupBy(r => r.TypeOf)
                   .OrderByDescending(g => g.Count())
                   .First();

            PrefferedType = typeOf.Key;
        }

    }
}
