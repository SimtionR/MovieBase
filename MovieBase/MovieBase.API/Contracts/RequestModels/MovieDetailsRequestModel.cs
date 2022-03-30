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

        public List<int> GenresId { get; set; } = new List<int>();
        public List<int> ActorsId { get; set; } = new List<int>();

        public double MetaScore { get; set; }
        public double UserRating { get; set; }
    }
}
