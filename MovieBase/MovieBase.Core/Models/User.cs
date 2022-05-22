using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class User :IdentityUser
    {
        public User()
        {
            Messages = new HashSet<ChatMessage>();
        }
        
        public Profile Profile { get; set; }
        public virtual ICollection<ChatMessage> Messages{ get; set; }
    }
}
