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
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public List<Movie> CastActor { get; set; } = new List<Movie>();
        public List<Movie> CastDirector { get; set; } = new List<Movie>();
        public List<Movie> CastSoundtrack { get; set; } = new List<Movie>();
        public List<Movie> CastProducer { get; set; } = new List<Movie>();

    }
}
