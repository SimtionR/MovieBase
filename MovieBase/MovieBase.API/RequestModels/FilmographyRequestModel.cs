using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.RequestModels
{
    public class FilmographyRequestModel
    {
        public List<int> CastAsActorIdList { get; set; }
        public List<int> CastAsDirectorList { get; set; }
        public List<int> CastAsSoundtrackList { get; set; }
        public List<int> CastAsProducesList { get; set; }

    }
}
