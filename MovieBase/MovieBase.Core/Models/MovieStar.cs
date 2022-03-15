using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class MovieStar : Person
    {
        public int Id { get; set; }
        public PersonalDetails PersonalDetails { get; set; }
        public Filmography Filmography { get; set; }
        public List<Award> Awards { get; set; } = new List<Award>();
  
    }
}
