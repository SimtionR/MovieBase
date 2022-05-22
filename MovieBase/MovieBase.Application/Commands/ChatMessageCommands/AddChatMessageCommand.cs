using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Commands.ChatMessageCommands
{
    public class AddChatMessageCommand : IRequest <ChatMessage>
    {
        public int Id { get; set; }       
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime SendOn { get; set; }
        public string UserId { get; set; }
        //public virtual User Sender { get; set; }
    }
}
