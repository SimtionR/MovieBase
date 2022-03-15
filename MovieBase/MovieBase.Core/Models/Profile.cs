using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<Movie> WatctList { get; set; } = new List<Movie>();
        public List<Movie> Ratings { get; set; } = new List<Movie>();
        public List<UserReview> Reviews { get; set; } = new List<UserReview>();
        public List<Movie> PlayList { get; set; }= new List<Movie>();
    }
}