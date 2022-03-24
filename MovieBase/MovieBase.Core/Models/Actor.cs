using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class Actor : Person
    {
        public int Id { get; set; }
        public int PersonalDetailsId { get; set; }
        public PersonalDetails PersonalDetails { get; set; }
        public int FilmographyId { get; set; }
        
        public List<Award> Awards { get; set; } = new List<Award>();
    }
}
