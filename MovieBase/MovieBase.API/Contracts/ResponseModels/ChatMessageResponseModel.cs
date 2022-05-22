using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Contracts.ResponseModels
{
    public class ChatMessageResponseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime SendOn { get; set; }
        public string UserId { get; set; } //senderId
        //public virtual User Sender { get; set; }
    }
}
