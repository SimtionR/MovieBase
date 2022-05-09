using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands
{
    public class AddMovieDetailsCommand : IRequest<MovieDetails>
    {
        /* public MovieDetails NewMovieDetails { get; set; }
         public List<int> ListOfActorsId;
         public List<int> ListOfGenresId;*/

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public double MetaScore { get; set; }
        public double UserRating { get; set; }
        public List<int> ActorsId { get; set; }
        public List<int> GenresId { get; set; }


    }
}
