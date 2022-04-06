using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.RequestModels
{
    public class MovieDetailsRequestModel
    {
        public int MovieId { get; set; }

        public List<int> GenresId { get; set; } = new List<int>();
        public List<int> ActorsId { get; set; } = new List<int>();

        public double MetaScore { get; set; }
        public double UserRating { get; set; }
        /*public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Actor> Actors { get; set; } = new List<Actor>();*/
    }
}
