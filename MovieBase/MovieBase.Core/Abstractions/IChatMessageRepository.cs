using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Abstractions
{
    public interface IChatMessageRepository
    {
        public  Task<IEnumerable<ChatMessage>> GetAllMessagesAsync();
        public  Task<ChatMessage> CreateAsync(ChatMessage message);
    }
}
