using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.StrategyRecommandation
{
    public class MovieBaseRecommandation : IStrategyRecommandation
    {
        public Movie Decision(UserPreferences userPreferences, List<Movie> movieBase)
        {
            try
            {
                var movie = movieBase.
                Where(m => m.TypeOf == userPreferences.PrefferedType
                && m.MovieDetails.MetaScore > userPreferences.MetaScoreTaste
                && m.MovieDetails.UserRating > userPreferences.UserRatingTaste).First();

                return movie;
            }
            catch (Exception ex)
            {
                throw new Exception("Try to add more movies in your watchlist, so we can get a better idea of your tastes");
            }


        }
    }
}
