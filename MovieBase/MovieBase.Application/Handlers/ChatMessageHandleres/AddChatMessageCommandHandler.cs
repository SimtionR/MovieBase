using AutoMapper;
using MediatR;
using MovieBase.Application.Commands.ChatMessageCommands;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers.ChatMessageHandleres
{
    public class AddChatMessageCommandHandler : IRequestHandler<AddChatMessageCommand, ChatMessage>
    {
        private readonly IChatMessageRepository _repo;
        private readonly IMapper _mapper;
        public AddChatMessageCommandHandler(IChatMessageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ChatMessage> Handle(AddChatMessageCommand request, CancellationToken cancellationToken)
        {
            var chatMessage = _mapper.Map<ChatMessage>(request);

            var result = await _repo.CreateAsync(chatMessage);

            return result;
        }
    }
}
