using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Contracts.ResponseModels
{
    public class MovieDetailsResponseModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Actor> Actors { get; set; } = new List<Actor>();

        public double MetaScore { get; set; }
        public double UserRating { get; set; }
    }
}
