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
        public List<Movie> WatctList { get; set; }
        public List<Movie> Ratings { get; set; }
        public List<UserReview> Reviews { get; set; }
        public List<Movie> PlayList { get; set; }
    }
}