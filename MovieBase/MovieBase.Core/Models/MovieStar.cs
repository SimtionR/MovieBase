using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class MovieStar : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public PersonalDetails PersonalDetails { get; set; }
        public Filmography Filmography { get; set; }
        public List<Award> Awards { get; set; }
  
    }
}
