using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MoviePhoto { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string TypeOf { get; set; }
        public string Photo { get; set; }
        public List<Genre> Genres {get; set;} = new List<Genre>();
        public List<MovieStar> Actors { get; set; } = new List<MovieStar>();
        public MovieStar Director { get; set; }
        public List<MovieStar> Writers  { get; set; } = new List<MovieStar>();
        public double MetaScore { get; set; }
        public double UserRating { get; set; }
        public List<UserReview> UsersReview { get; set; } = new List<UserReview>();
        public List<CriticReview> CriticsReview { get; set; } = new List<CriticReview>();
    }

    
 

}
