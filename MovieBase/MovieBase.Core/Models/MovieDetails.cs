using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class MovieDetails
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Actor> Actors { get; set; } = new List<Actor>();

        public double MetaScore { get; set; }
        public double UserRating { get; set; }
        public List<UserReview> UsersReview { get; set; } = new List<UserReview>();
        public List<CriticReview> CriticsReview { get; set; } = new List<CriticReview>();
    }
}
