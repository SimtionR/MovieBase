using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.StrategyRecommandation
{
    public interface IStrategyRecommandation
    {
        public Movie Decision(UserPreferences userPreferences, List<Movie> movies);
    }
}
