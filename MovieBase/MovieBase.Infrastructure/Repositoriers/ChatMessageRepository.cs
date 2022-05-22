using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Repositoriers
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly MovieBaseDbContext _ctx;
        public ChatMessageRepository(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<ChatMessage> CreateAsync(ChatMessage message)
        {
            await _ctx.AddAsync(message);
            await _ctx.SaveChangesAsync();

            return message;
        }

        public async Task<IEnumerable<ChatMessage>> GetAllMessagesAsync()
        {
            return null;
        }
    }
}
