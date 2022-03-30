using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.RequestModels
{
    public class PersonalDetailsRequestModel
    {
       
        public string Birthdate { get; set; }
        public string History { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
