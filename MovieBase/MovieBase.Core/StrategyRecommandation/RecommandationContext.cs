using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.StrategyRecommandation
{
    public class RecommandationContext
    {
        private IStrategyRecommandation _strategy;


        public void SetStrategy(IStrategyRecommandation strategy)
        {
            _strategy = strategy;
        }

        public Movie RecommandMovie(List<Movie> movies, UserPreferences userPreferences)
        {
            if (_strategy == null)
                Console.WriteLine("No Recommandation");


            return _strategy.Decision(userPreferences, movies);


        }

    }
}
