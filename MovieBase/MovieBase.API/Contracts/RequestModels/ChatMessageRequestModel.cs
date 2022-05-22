using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Contracts.RequestModels
{
    public class ChatMessageRequestModel
    {
        public ChatMessageRequestModel()
        {
            UserName = "";
            UserId = "";
        }

        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime SendOn { get; set; }
        public string UserId { get; set; } //senderId
        //public virtual User Sender { get; set; }

    }
}
