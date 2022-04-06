using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.StrategyRecommandation
{
    public class WatchListRecommandation : IStrategyRecommandation
    {
        public Movie Decision(UserPreferences userPreferences, List<Movie> watchList)
        {
            var allCritieriaMovie = MovieWithAllCritieria(userPreferences, watchList);

            if (allCritieriaMovie != null)
            {
                return allCritieriaMovie;
            }

            else
            {
                var metaCriticCrietiera = MovieWithMetaCritic(userPreferences, watchList);
                if (metaCriticCrietiera != null)
                    return metaCriticCrietiera;
            }

            var userRatedCritiera = MovieWithUserRated(userPreferences, watchList);
            return userRatedCritiera;


        }

        private Movie MovieWithUserRated(UserPreferences userPreferences, List<Movie> watchList)
        {
            var movie = watchList.
               Where(m => m.TypeOf == userPreferences.PrefferedType
               && m.MovieDetails.UserRating > userPreferences.UserRatingTaste).
               FirstOrDefault();

            return movie;
        }

        private Movie MovieWithAllCritieria(UserPreferences userPreferences, List<Movie> movies)
        {
            var movie = movies.
                Where(m => m.TypeOf == userPreferences.PrefferedType
                && m.MovieDetails.MetaScore > userPreferences.MetaScoreTaste
                && m.MovieDetails.UserRating > userPreferences.UserRatingTaste).FirstOrDefault();

            return movie;
        }

        private Movie MovieWithMetaCritic(UserPreferences userPreferences, List<Movie> movies)
        {
            var movie = movies.
                Where(m => m.TypeOf == userPreferences.PrefferedType
                && m.MovieDetails.MetaScore > userPreferences.MetaScoreTaste).
                FirstOrDefault();

            return movie;
        }
    }
}
