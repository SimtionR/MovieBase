using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.RequestModels;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.Application.Commands.ChatMessageCommands;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatController : ApiController
    {
        private readonly UserManager<User> _userMananger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ChatController(UserManager<User> userManager, IMapper mapper, IMediator mediator)
        {
            _userMananger = userManager;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("test")]
        public async Task<ActionResult> Test()
        {
            var currentUser = await _userMananger.GetUserAsync(User);

            return null;
        }

        [HttpPost]
        [Route("createMessage")]
        public async Task<ActionResult<ChatMessageResponseModel>> Create(ChatMessageRequestModel messageModel)
        {
            messageModel.UserId = User.Identity.Name;
            //var sender = await _userMananger.GetUserNameAsync()
            //messageModel.UserId = sender.Id;

            var command = _mapper.Map<AddChatMessageCommand>(messageModel);

            var result = await _mediator.Send(command);

            return _mapper.Map<ChatMessageResponseModel>(result);
        }
    }
}
