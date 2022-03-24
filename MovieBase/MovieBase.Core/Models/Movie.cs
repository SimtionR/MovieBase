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
        public int MovieDetailsId { get; set; }
        public MovieDetails MovieDetails { get; set; }


    }

    
 

}
