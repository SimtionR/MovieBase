using AutoMapper;
using MovieBase.API.Contracts.RequestModels;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.Application.Commands.ChatMessageCommands;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Profiles
{
    public class ChatMessageProfile : AutoMapper.Profile
    {
        public ChatMessageProfile()
        {
            CreateMap<ChatMessageRequestModel, AddChatMessageCommand>();
            CreateMap<AddChatMessageCommand, ChatMessage>();
            CreateMap<ChatMessage, ChatMessageResponseModel>();
        }
    }
}
