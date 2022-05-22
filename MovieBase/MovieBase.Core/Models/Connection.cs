using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class Connection
    {
        public int Id { get; set; }
        public int ProfileConnectionId  { get; set; }
        public string ProfileUserName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
