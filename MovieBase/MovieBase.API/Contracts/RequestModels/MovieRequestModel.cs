using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.RequestModels
{
    public class MovieRequestModel
    {
        public string Name { get; set; }
        public string MoviePhoto { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string TypeOf { get; set; }
   
    }
}
