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
        public TypeOf TypeOfMovie{ get; set; }
        public List<Genre> Genre { get; set; }
        public List<string> Gallery { get; set; }
        public List<MovieStar> Actors { get; set; }
        public MovieStar Director { get; set; }
        public List<MovieStar> Writers { get; set; }
        public double MetaScore { get; set; }
        public double UserRating { get; set; }
        public List<UserReview> UsersReview { get; set; }
        public List<CriticReview> CriticsReview { get; set; }
    }

    
 

}
