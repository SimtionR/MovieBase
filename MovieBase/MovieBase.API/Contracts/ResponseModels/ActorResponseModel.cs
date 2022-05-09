using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Contracts.ResponseModels
{
    public class ActorResponseModel
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
