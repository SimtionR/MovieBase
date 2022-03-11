using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class Filmography
    {
        public int Id { get; set; }
        public int MovieStarId { get; set; }
        public List<Movie> Actor { get; set; }
        public List<Movie> Director { get; set; }
        public List<Movie> Soundtrack { get; set; }
        public List<Movie> Producer { get; set; }

    }
}
